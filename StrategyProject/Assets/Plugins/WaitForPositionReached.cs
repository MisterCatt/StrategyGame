using UnityEngine;

public class WaitForPositionReached : CustomYieldInstruction
{
    private Transform startPosition, endPosition;
    public WaitForPositionReached(Transform yourPosition, Transform targetPosition)
    {
        startPosition = yourPosition;
        endPosition = targetPosition;
    }

    public override bool keepWaiting {
        get
        {
            return (startPosition.position == endPosition.position);
        }
    }
}
