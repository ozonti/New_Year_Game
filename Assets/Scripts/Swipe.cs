using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    private Vector2 mouseDownPosition;
    private Vector2 mouseUpPosition;
    public bool detectSwipeOnlyAfterRelease = false;

    public float speed = 20;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    public GameObject card;
    
    public float minDistanceForSwipe = 20f;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseUpPosition = Input.mousePosition;
            mouseDownPosition = Input.mousePosition;
        }

        if (!detectSwipeOnlyAfterRelease && Input.GetMouseButton(0))
        {
            mouseDownPosition = Input.mousePosition;
            DetectSwipe();
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDownPosition = Input.mousePosition;
            DetectSwipe();
        }
    }

    public void StartAnimation(int i)
    {
        Animator animator = card.GetComponent<Animator>();
        if (i == 1)
        {
            animator.SetTrigger("Left");
            if (Progress.Instance.PlayerInfo.cardColor > 3)
            {
                Progress.Instance.PlayerInfo.heartId -= 1;
            }
            else
            {
                Progress.Instance.PlayerInfo.cardCountCurr += 1;
            }

            Progress.Instance.PlayerInfo.cardId += 1;
            Invoke("DeletePrefab", 0.8f);
        }
        else
        {
            animator.SetTrigger("Right");

            if (Progress.Instance.PlayerInfo.cardColor < 4)
            {
                Progress.Instance.PlayerInfo.heartId -= 1;
            }
            else
            {
                Progress.Instance.PlayerInfo.cardCountCurr += 1;
            }

            Progress.Instance.PlayerInfo.cardId += 1;
            Invoke("DeletePrefab", 0.8f);
        }
    }

    void DetectSwipe()
    {
        if (Vector2.Distance(mouseDownPosition, mouseUpPosition) > minDistanceForSwipe)
        {
            float x = mouseDownPosition.x - mouseUpPosition.x;
            float y = mouseDownPosition.y - mouseUpPosition.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    Debug.Log("Right Swipe");
                    StartAnimation(2);
                }
                else
                {
                    Debug.Log("Left Swipe");
                    StartAnimation(1);
                }
            }
            else
            {
                if (y > 0)
                {
                    Debug.Log("Down Swipe");
                }
                else
                {
                    Debug.Log("Up Swipe");
                }
            }

            mouseUpPosition = mouseDownPosition;
        }
    }


    public void DeletePrefab()
    {
        Destroy(card);
    }
}
