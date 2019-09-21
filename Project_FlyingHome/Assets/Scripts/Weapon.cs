using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    private int coolDown = 2;
    private float attackTimer;
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            attackTimer = coolDown;
            Shoot();
        }
    }

    void Shoot()
    {
        //prefab shooting
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}
