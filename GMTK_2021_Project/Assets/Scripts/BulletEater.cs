using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEater : MonoBehaviour
{
    [SerializeField] AmmoStat ammoSource;

    void Awake()
    {
        if(ammoSource == null)
        {
            Debug.LogWarning("There is no AmmoStat component associated with this Eater!");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGERED");
        Projectile p = other.GetComponent<Projectile>();
        if(p != null)
        {
            // If a projectile contacts the trigger field, then add the proper number of bullets to the player's
            // bullet stock and then make the projectile disappear

            if(ammoSource != null)
                ammoSource.AddBullets(p.GetBulletValue());
            p.Vanish();
        }
            
    }
}
