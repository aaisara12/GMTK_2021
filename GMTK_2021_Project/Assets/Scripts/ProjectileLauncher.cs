using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] float shotsPerSecond = 1;


    [SerializeField] ProjectilePool pool;

    float lastShot = 0;

    void Awake()
    {
        if(pool == null)
            Debug.LogWarning("Launcher does not have a projectile pool to use!");
        if(firePoint == null)
            Debug.LogWarning("No fire point specified");
    }

    // Update is called once per frame
    void Update()
    {
        if(firePoint == null || pool == null) {return;}

        if(Time.time - lastShot > 1/shotsPerSecond)
        {
            var newProj = pool.Get();       // This is where we try to get another projectile from the queue (note that the projectiles will automatically enqueue themselves back in after expiring)

            newProj.SetActive(true);        // We NEED this line because the projectiles are disabled when we grab them from the queue

            newProj.transform.position = firePoint.position;
            newProj.transform.rotation = firePoint.rotation;
    
            lastShot = Time.time;
        }
    }


}
