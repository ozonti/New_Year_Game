using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    public Image bar;
    public int maximum;
    public int cur;




    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        maximum = Progress.Instance.PlayerInfo.cardCountMax;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        cur = Progress.Instance.PlayerInfo.cardCountCurr;
    }

    public void GetCurrentFill()
    {
        float fillAmount = (float)cur / (float)maximum;
        bar.fillAmount = fillAmount;
    }
}
