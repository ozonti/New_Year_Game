using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatioFilter : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform rectTransform;

    public void Awake()
    {

        if (Screen.width <= 490)
        {

            rectTransform = GetComponent<RectTransform>();
            StretchObject();
        }

    }

    private void StretchObject()
    {
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }
}