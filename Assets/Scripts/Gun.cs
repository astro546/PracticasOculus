using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/* Clase del arma */
public class Gun : MonoBehaviour
{ 
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float bulletSpeed = 10;

    void Fire(){
        Quaternion bulletRotation = bulletSpawnPoint.rotation * Quaternion.Euler(0.0f, 90.0f, 0.0f);
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletRotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float fireButton = Input.GetAxisRaw("Fire1");
        if (fireButton == 1){
            Fire();
        } 
    }
}
