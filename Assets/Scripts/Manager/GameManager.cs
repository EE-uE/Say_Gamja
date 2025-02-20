using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    UIManager uiManager;

    public GameObject SettingPannel;

    public UIManager UIManager { get { return uiManager; } }


    private void Awake()
    {
        gameManager = this;
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SettingPannel.SetActive(true);
    }

    // 점수추가
    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }
}
