using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] float shotsPerSecond = 1;


    [SerializeField] ProjectilePool pool;
    [SerializeField] AmmoStat optionalAmmoSource;       // This is optional so that we can have a unit have infinite ammo

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
            lastShot = Time.time;       // We want to update the last shot time regardless of whether any bullets are actually shot to prevent constant checking of this loop in the case nothing is shot

            if(optionalAmmoSource != null)                  // If we do have an ammo source, then expend bullets
            {
                if(!optionalAmmoSource.TryUseBullets(1))    // If we are all out of bullets to use, then don't shoot any more
                    return;
            }

            var newProj = pool.Get();       // This is where we try to get another projectile from the queue (note that the projectiles will automatically enqueue themselves back in after expiring)

            

            newProj.transform.position = firePoint.position;
            newProj.transform.rotation = firePoint.rotation;

            
            // This is a messy way of setting the "no damage tag" for the projectile (messy bc this is supposed to be generic code)
            Projectile projectile = newProj.GetComponent<Projectile>();
            if(projectile != null)
                projectile.noDamageTag = gameObject.tag;
            


            // It's important that we enable the bullet AFTER setting the position and rotation so that the force is applied in
            // the proper direction on enable

            newProj.SetActive(true);        // We NEED this line because the projectiles are disabled when we grab them from the queue
    
            


            
        }
    }


}
