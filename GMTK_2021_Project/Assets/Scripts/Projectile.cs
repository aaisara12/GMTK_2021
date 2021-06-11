using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float force = 1;


    // Update is called once per frame

    void OnEnable()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * force);
    }
}
