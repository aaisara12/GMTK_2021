using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IPooledGameObject
{
    [SerializeField] float force = 1;
    [SerializeField] float expireTime = 5;
    float timeOfEnable = 0;


    // NOTE:  We use the below structure in order to catch mistakenly assigning a pool more than once to a given projectile
    private ProjectilePool _pool;       // Note that we need this private version of the pool instance in order to make the check whether a pool has been assigned to it
    public ProjectilePool pool
    {
        get{ return _pool;}
        set
        {
            if(_pool == null)
                _pool = value;
            else
                throw new System.Exception("Attempted to assign multiple pools to the same projectile!");   // A pool should only be assigned once after the instantiation of the projectile by the pooling system
        }
    }


    // Update is called once per frame

    void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
        timeOfEnable = Time.time;

        Debug.Log("ENABLING PROJ");
    }


    void Update()
    {
        if(Time.time - timeOfEnable > expireTime)
        {
            pool.ReturnToPool(gameObject);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }




}

// This interface allows us to give any game object the "credentials" it needs to be accepted/used as a pooled object
public interface IPooledGameObject
{
    ProjectilePool pool {get; set;}
}
