using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using YG;




[System.Serializable]

public class PlayerInfo
{
    public int cardId = 0;
    public int heartId = 3;
    public int cardColor;
    public int cardCountMax = 20;
    public int cardCountCurr = 0;





    public int coins = 0;
    public int girlIdx = 0;
    public int wearIdx = 0;
    public int clickStep = 1;
    public int BGID = 0;
    public int GirlLoadIndex = 0;

    public bool[] BWear = new bool[25];
}

public class Progress : MonoBehaviour
{
    public AudioSource audio;


    public PlayerInfo PlayerInfo;
    public static Progress Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        audio.Play();
    }
    void Start()
    {
        //Invoke("loadSaveCloud", 0.5f);
    }


    private void OnEnable() => YandexGame.GetDataEvent += loadSaveCloud;

    private void OnDisable() => YandexGame.GetDataEvent -= loadSaveCloud;



    private void loadSaveCloud()
    {
        PlayerInfo.coins = YandexGame.savesData.YA_coins;
        PlayerInfo.GirlLoadIndex = YandexGame.savesData.YA_GirlLoadIndex;
        PlayerInfo.wearIdx = YandexGame.savesData.YA_wearIdx;
        PlayerInfo.clickStep = YandexGame.savesData.YA_clickStep;
        PlayerInfo.BGID = YandexGame.savesData.YA_BGID;
        PlayerInfo.BWear = YandexGame.savesData.YA_BWear;


        if (PlayerInfo.BWear.Length == 0)
        {
            bool[] temp = new bool[25];
            for (int i = 0; i< 25; i++){
                temp[i] = true;
            }
            PlayerInfo.BWear = temp;
        }


        if (PlayerInfo.clickStep == 0)
        {
            PlayerInfo.clickStep = 1;
        }
    }

    public void MySave()
    {
        YandexGame.savesData.YA_coins = PlayerInfo.coins;
        YandexGame.savesData.YA_GirlLoadIndex = PlayerInfo.GirlLoadIndex;
        YandexGame.savesData.YA_wearIdx = PlayerInfo.wearIdx;
        YandexGame.savesData.YA_clickStep = PlayerInfo.clickStep;
        YandexGame.savesData.YA_BGID = PlayerInfo.BGID;
        YandexGame.savesData.YA_BWear = PlayerInfo.BWear;

        YandexGame.SaveProgress();
    }

}