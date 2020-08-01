using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Singleton")]
    public static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    [Header("References")]
    public Text playerHealthText;
    public Text currentTimeText;
    public Text coinCollectedText;

    [Header("Settings")]
    public float timeStart;
    [HideInInspector] public float currentTime;
    float coinInitialValue = 0f;
    public CanvasGroup gameOverScreen;
    public CanvasGroup victoryScreen;
    public float alphaScreenValue;

    void Awake()
    {
        instance = this;
        currentTime = timeStart;
    }

    public void UpdateTime()
    {
        currentTime -= Time.deltaTime;
        currentTimeText.text = currentTime >= 0 ? currentTime.ToString("F2").Replace(",", ".") : "0.00";
    }

    public void RestartTime()
    {
        currentTime = timeStart;
    }

    public void UpdatePlayerHealthUI(int health)
    {
        playerHealthText.text = health > 0 ? health.ToString() : "0";
    }

    public void ResetPlayerHealthUI(int healthValue)
    {
        playerHealthText.text = healthValue.ToString(); ;
    }

    public void UpdateCoinUI(int coinValue)
    {
        coinCollectedText.text = coinValue.ToString();
    }

    public void ResetCoinUI()
    {
        coinCollectedText.text = coinInitialValue.ToString();
    }

    public void ShowGameOverScreen(bool isActivated)
    {
        gameOverScreen.alpha = isActivated ? alphaScreenValue : 0;        
    }

    public void ShowVictoryScreen(bool isActivated)
    {
        victoryScreen.alpha = isActivated ? alphaScreenValue : 0;
    }
}
