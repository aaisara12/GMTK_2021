using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float smoothTime = 0.2f;

    Vector2 currentVelocity = Vector2.zero;
    Vector2 targetVelocity = Vector2.zero;
    Vector2 currentVel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;  // We normalize here because normalizing at current velocity would prevent it from ever reaching zero vector

        currentVelocity = Vector2.SmoothDamp(currentVelocity, targetVelocity, ref currentVel, smoothTime);
        transform.Translate((currentVelocity) * speed * Time.deltaTime);
    }
}
