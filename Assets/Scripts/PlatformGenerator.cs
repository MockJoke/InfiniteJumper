using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject genPoint;
    [SerializeField] private int distanceBw;

    [SerializeField] private float distanceBwMin = 0f;
    [SerializeField] private float distanceBwMax = 3f;

    private float platformWidth;

    //[SerializeField] private TimerGenerator timerGenerator;
    [SerializeField] private int randomGenCount = 2;  

    public ObjectPooler objectPooler; 
    void Start()
    {
        objectPooler = ObjectPooler.SharedInstance;
        //timerGenerator = FindObjectOfType<TimerGenerator>();

        genPoint = GameObject.Find("PlatformGenPoint");

        platformWidth = platformPrefab.GetComponent<BoxCollider2D>().size.x;    
    }
 
    void Update()
    {
        if(transform.position.x < genPoint.transform.position.x)
        {   
            distanceBw = (int)Random.Range(distanceBwMin, distanceBwMax);

            transform.position = new Vector2(transform.position.x + platformWidth + distanceBw, transform.position.y);

            GameObject platform = objectPooler.GetPooledObject(1); 

            platform.transform.position = transform.position;
            platform.transform.rotation = transform.rotation;
            platform.SetActive(true);

            if (Random.Range(0f, 5f) < randomGenCount)
            {
                TimerGenerator.Instance.SpawnTimer(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
            }
        }
    }
}
