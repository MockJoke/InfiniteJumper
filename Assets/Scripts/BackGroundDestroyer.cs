using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject destructionPoint;

    void Start()
    {
        destructionPoint = GameObject.Find("BackGroundDestructionPoint");
    }

    void Update()
    {
        if (transform.position.x < destructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
