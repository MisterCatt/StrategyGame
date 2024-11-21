using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Astar
{
    public static Node GetPath(Vector3Int start, Vector3Int end, int length)
    {
        var openList = new List<Node> { new(start) };
        var closedList = new List<Node>();

        var current = new Node(start);

        

        if (!IsValidPath(current, new Node(end)))
            return null;

        while (openList.Any())
        {
            current = openList[0];

            foreach (var node in openList.Where(node => node.F <= current.F))
            {
                current = node;
            }

            openList.Remove(current);
            closedList.Add(current);

            if (start == end)
            {
                return current;
            }

            var neighbors = new List<Node>();

            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    foreach (var tile in GridManager.Tiles.Where(tile => tile.x == current.tile.x - x && tile.y == current.tile.y - y))
                    {
                        var node = new Node(tile);

                        neighbors.Add(node);
                        break;
                    }
                }
            }

            foreach (var child in neighbors)
            {
                child.previous = current;

                if (closedList.Any(node => IsSameTile(node.tile, child.tile)) || child.tile.z > 0)
                    goto Repeat;

                child.SetG(current.G + LevelManager.Instance.GetTileData(child.tile).walkingCost);

                child.SetH(Mathf.Pow(child.tile.x - end.x, 2) + Mathf.Pow(child.tile.y - end.y, 2) / 100);

                foreach (var node in openList.Where(node => IsSameTile(child.tile, node.tile)).Where(node => child.G > node.G))
                {
                    goto Repeat;
                }


                openList.Add(child);

            Repeat: continue;
            }
        }

        


        return new Node(start);
    }

    private static bool IsValidPath(Node start, Node end)
    {
        if (end == null)
            return false;
        if (start == null)
            return false;
        if (end.Height >= 1)
            return false;
        return true;
    }

    public static bool IsSameTile(Vector3Int aFirst, Vector3Int aSecond)
    {
        if (aFirst.x == aSecond.x && aFirst.y == aSecond.y) return true; else return false;
    }
}

public class Node
{
    public Node(Vector3Int pos)
    {
        tile = pos;
    }

    public Vector3Int tile;

    public float F => G + H;
    public float G { get; private set; }
    public float H { get; private set; }

    public void SetG(float g) => G = g;
    public void SetH(float h) => H = h;

    public int Height = 0;

    public Node previous = null;
}
