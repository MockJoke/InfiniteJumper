using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform; 
    private Vector3 offset; 

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform; 
        offset = transform.position - playerTransform.position; 
    }

    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x + offset.x, transform.position.y, transform.position.z); 
    }
} 
