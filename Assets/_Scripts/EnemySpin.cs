using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpin : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
  
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
