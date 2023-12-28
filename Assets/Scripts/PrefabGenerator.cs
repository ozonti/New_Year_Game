using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabGenerator : MonoBehaviour
{
    public GameObject Pr;
    public int prID;
    public List<Sprite> Images;

    void Update()
    {
        if (prID < Progress.Instance.PlayerInfo.cardId)
        {
            Invoke("Generate", 0.6f);
            prID = Progress.Instance.PlayerInfo.cardId;
        }

    }

    public void Generate()
    {
        GameObject pre = Instantiate(Pr);

        Image imageComp = pre.GetComponent<Image>();
        int rand = Random.Range(0, 8);
        Progress.Instance.PlayerInfo.cardColor = rand;
        Debug.Log(rand);
        imageComp.sprite = Images[rand];

        RectTransform rectTransform = pre.GetComponent<RectTransform>();

        var scale = rectTransform.sizeDelta;
        scale.x = 2.27f;
        scale.y = 3.75f;
        rectTransform.sizeDelta = scale;
        pre.transform.SetParent(transform);
    }
}
