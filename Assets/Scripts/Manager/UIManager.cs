using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject SettingPannel;
    public Text NowScoreText;
    public Text BestScoreText;
    public Text ScoreText;  

    void Start()
    {
        //if (restartText == null)
        //{
        //    Debug.LogError("restart text is null");
        //}

        if (NowScoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        SettingPannel.gameObject.SetActive(false);
    }

    //restart ���ִ°�
    public void SetRestart()
    {
        //SettingPannel.gameObject.SetActive(true);
    }

    // ���� �ֽ�ȭ
    public void UpdateScore(int score)
    {
        NowScoreText.text = score.ToString();
        ScoreText.text = score.ToString();
    }
}
