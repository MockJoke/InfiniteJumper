using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTimer : MonoBehaviour
{
    [SerializeField] private int extraTime = 10;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            scoreManager.timerCount += extraTime;

            gameObject.SetActive(false);
        }
    }
}
