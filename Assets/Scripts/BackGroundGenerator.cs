using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private GameObject genPoint;

    RectTransform backgroundTransform; 

    private float backgroundWidth;

    public ObjectPooler objectPooler;
    void Start()
    {
        objectPooler = ObjectPooler.SharedInstance;

        genPoint = GameObject.Find("BackGroundGenPoint");

        backgroundWidth = backgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void Update()
    {
        if (transform.position.x < genPoint.transform.position.x)
        {

            transform.position = new Vector2(transform.position.x + backgroundWidth, transform.position.y);

            GameObject platform = objectPooler.GetPooledObject(0);

            platform.transform.position = transform.position;
            platform.transform.rotation = transform.rotation;
            platform.SetActive(true);
        }
    }
}
