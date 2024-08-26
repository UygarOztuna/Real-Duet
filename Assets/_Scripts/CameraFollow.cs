using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;

    [SerializeField] Transform player;
    [SerializeField] private float smoothSpeed;
    public Vector3 offset;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void LateUpdate()
    {

        Vector3 desiredPosition = player.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
