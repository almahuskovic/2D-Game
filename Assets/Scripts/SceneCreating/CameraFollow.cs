using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
//using System.Numerics;
using UnityEngine;

public static class CameraLimit
{
    public static bool isLeftLimitReached = false;
}
public class CameraFollow : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Transform player;
#pragma warning restore 0649

    [Range(0,5f)]
    public float smooth = 0.1f;

    public float minValue=-1;
    public float offset;
    float distance = 1000f;
    public float leftLimit;
    Vector3 playersLastPosition;
   

    private void Awake()
    {
        playersLastPosition = player.position;
    }
    
    void FixedUpdate()
    {
        leftLimit = GeometryUtility.CalculateFrustumPlanes(Camera.main)[0].distance;
        if (player.position.x <= Math.Abs(leftLimit)+ 0.5 && leftLimit<0)
            CameraLimit.isLeftLimitReached = true;
        else
            CameraLimit.isLeftLimitReached = false;

        if(!PlayerGoingBack.isGoingBack && player.position.x>=playersLastPosition.x)
        {
            Vector3 playerPosition = transform.position;
            playerPosition.x = player.position.x;
            playerPosition.y = player.position.y;
            playerPosition.z = player.position.z;
            playerPosition.z -= offset;
            playersLastPosition = player.position;
            if (player.position.x > distance)
            {
                offset += 2;
                distance += 1000;
            }
            Vector3 newPosition = Vector3.Lerp(transform.position, playerPosition, smooth);//staviti u plmov
            //transform.position = Vector3.SmoothDamp(transform.position, playerPosition,, smooth);
            newPosition = new Vector3(newPosition.x, Mathf.Clamp(newPosition.y,minValue, Mathf.Infinity), newPosition.z);
            transform.position = newPosition;

        }
    }
}
