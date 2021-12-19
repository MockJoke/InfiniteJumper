using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class HomeScreenManager : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(onClickPlayButton); 
    }

    void onClickPlayButton()
    {
        SceneManager.LoadScene(1); 
    }
}
