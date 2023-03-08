using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 襪子發射 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float time, startTime;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            Short();
        }
    }
    void Short()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
