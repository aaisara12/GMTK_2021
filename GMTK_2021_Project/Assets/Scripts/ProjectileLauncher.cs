using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] Transform firePoint;
    [SerializeField] float shotsPerSecond = 1;

    float lastShot = 0;

    void Awake()
    {
        if(projectile == null)
            Debug.LogWarning("Launcher does not have a projectile to launch");
        if(firePoint == null)
            Debug.LogWarning("No fire point specified");
    }

    // Update is called once per frame
    void Update()
    {
        if(firePoint == null || projectile == null) {return;}

        if(Time.time - lastShot > shotsPerSecond)
        {
            GameObject.Instantiate(projectile, firePoint, true);
            lastShot = Time.time;
        }
    }
}
