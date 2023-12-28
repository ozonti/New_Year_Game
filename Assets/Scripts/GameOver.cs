using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;




public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject PrGenerator;



    void Update()
    {
        if (Progress.Instance.PlayerInfo.heartId == 0)
        {
            Time.timeScale = 0;
            PrGenerator.SetActive(false);
            GameOverPanel.SetActive(true);
        }
        else if (Progress.Instance.PlayerInfo.currTime == 1)
        {
            Progress.Instance.PlayerInfo.currTime = 0;
            Time.timeScale = 0;
            PrGenerator.SetActive(false);
            GameOverPanel.SetActive(true);
            
        }
    }


    // Подписываемся на событие открытия рекламы в OnEnable
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;


    void Rewarded(int id)
    {
        if (id == 1)
        {
            Progress.Instance.PlayerInfo.heartId += 1;
            PrGenerator.SetActive(true);
            GameOverPanel.SetActive(false);
            Time.timeScale = 1;
        }

        else if (id == 2)
        {
            Progress.Instance.PlayerInfo.heartId = 3;
            PrGenerator.SetActive(true);
            GameOverPanel.SetActive(false);
            Time.timeScale = 1;

        }
    }


    public void AddHearts(int id)
    {
        YandexGame.RewVideoShow(id);
    }

}
