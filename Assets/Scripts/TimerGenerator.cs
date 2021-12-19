using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGenerator : MonoBehaviour
{
    private static TimerGenerator instance;

    public static TimerGenerator Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    [SerializeField] private GameObject timerPrefab; 

    public ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.SharedInstance; 
    }

    public void SpawnTimer(Vector3 spawnPosition) 
    {
        GameObject timer = objectPooler.GetPooledObject(2);

        timer.transform.position = spawnPosition;
        timer.transform.rotation = transform.rotation;
        timer.SetActive(true);
    }
}
