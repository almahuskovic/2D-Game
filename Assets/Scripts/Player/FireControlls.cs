using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class FireControlls : MonoBehaviour
{
#pragma warning disable 0649
    [Header("Fire controlls")]
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform playerFireContainer;
#pragma warning restore 0649
    [SerializeField]
    private float nextFire = 0.1f;
    [SerializeField]
    [Range(0.1f, 5f)]
    private float fireRate = 1f;

    [SerializeField]
    [Range(0,5f)]
    private float timeToDissapear=0.4f;
    
    float timer = 0;
    float makeAt = 0;
  
    GameObject newBullet=null;
    //When a bullet appears(first if), it gets destroys after certain time(second if)
    void Update()
    {
        timer += 1f * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                newBullet=Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, playerFireContainer);
                makeAt = timer;
                FindObjectOfType<AudioManager>().Play("dropSound");
            }
        }
      
        if (timer-timeToDissapear>=makeAt && newBullet != null)
        {
            Destroy(newBullet);
        }

    }
}
