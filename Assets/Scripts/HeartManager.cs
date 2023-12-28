using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public List<GameObject> Hearts;

    void Update()
    {
        for (int i = 0; i < Hearts.Count; i++)
        {
            Hearts[i].SetActive(false);
        }
        for (int i = 0; i < Progress.Instance.PlayerInfo.heartId; i++)
        {
            Hearts[i].SetActive(true);
        }
    }
}
