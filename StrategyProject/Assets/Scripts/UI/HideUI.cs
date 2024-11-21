using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HideUI : MonoBehaviour
{
    bool isLeft = false;

    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = (RectTransform)transform;
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void Update()
    {
        if(IsMouseOverUI())
        {
            isLeft = !isLeft;

            if (!isLeft)
            {
                rectTransform.anchoredPosition = new Vector3(284, transform.position.y, 0);
                transform.position = rectTransform.transform.position;
            }
            else
            {
                rectTransform.anchoredPosition = new Vector3(-284, transform.position.y, 0);
                transform.position = rectTransform.transform.position;
            }
        }
    }
}
