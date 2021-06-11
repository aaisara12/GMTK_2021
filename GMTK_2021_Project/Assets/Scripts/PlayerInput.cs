using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IUnitInput
{
    public Vector2 inputVector {get => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));}


}
