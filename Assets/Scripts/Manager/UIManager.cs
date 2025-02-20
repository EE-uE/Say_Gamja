using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI restartText;

    void Start()
    {
        //if (restartText == null)
        //{
        //    Debug.LogError("restart text is null");
        //}

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        //restartText.gameObject.SetActive(false);
    }

    // restart ���ִ°�
    //public void SetRestart()
    //{
    //    restartText.gameObject.SetActive(true);
    //}

    // ���� �ֽ�ȭ
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
