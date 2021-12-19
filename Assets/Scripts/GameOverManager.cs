using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button reloadButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private TextMeshProUGUI finalScoreText;
    public int score; 

    private ScoreManager scoreManager;

    void Start()
    {
        score = PlayerPrefs.GetInt("scoreCount"); 
        reloadButton.onClick.AddListener(onClickReloadButton); 
        quitButton.onClick.AddListener(onClickQuitButton);

        displayScore(); 
    }
    
    void displayScore()
    {
        finalScoreText.text = "Score: " + score; 
    }

    void onClickReloadButton()
    {
        SceneManager.LoadScene(1); 
    }

    void onClickQuitButton()
    {
        Application.Quit();
    }
}
