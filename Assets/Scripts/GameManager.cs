using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform platformGenerator;
    private Vector3 platformStartPoint;

    [SerializeField] private Transform backGroundGenerator; 
    private Vector3 backGroundStartPoint;

    [SerializeField] private PlayerController player;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList; 
    private BackGroundDestroyer[] backGroundList;

    private void Start()
    {
        platformStartPoint = platformGenerator.position;
        backGroundStartPoint = backGroundGenerator.position;
        playerStartPoint = player.transform.position;
    }

    public void RestartGame()
    {
        StartCoroutine("waitToRespawn"); 
    }

    public IEnumerator waitToRespawn()
    {
        player.gameObject.SetActive(false);

        player.jumpCount--; 

        yield return new WaitForSeconds(1f);

        platformList = FindObjectsOfType<PlatformDestroyer>(); 
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        backGroundList = FindObjectsOfType<BackGroundDestroyer>();
        for (int i = 0; i < backGroundList.Length; i++)
        {
            backGroundList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPoint; 
        platformGenerator.position = platformStartPoint;
        backGroundGenerator.position = backGroundStartPoint;
        player.gameObject.SetActive(true);
    }
}
