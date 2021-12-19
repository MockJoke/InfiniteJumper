using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public int scoreCount;
    
    public float timerCount; 

    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        scoreCount = PlayerPrefs.GetInt("scoreCount", 0); 
    }

    private void Update()
    {
        scoreCount = playerController.jumpCount; 
        scoreText.text = "Score: " + scoreCount;
        PlayerPrefs.SetInt("scoreCount", scoreCount); 

        timerCount -= Time.deltaTime; 
        timerText.text = "Time: " + Mathf.FloorToInt(timerCount);  

        if(timerCount < 0)
        {
            SceneManager.LoadScene(2); 
        }

        if(playerController.lifeCount < 0)
        {
            SceneManager.LoadScene(2); 
        }
    }
}
