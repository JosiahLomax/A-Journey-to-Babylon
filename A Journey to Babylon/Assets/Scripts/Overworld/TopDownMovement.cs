using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Update()
    {
        InputAction MoveAction = InputSystem.actions.FindAction("Move");

        horizontal = MoveAction.ReadValue<Vector2>().x;
        vertical = MoveAction.ReadValue<Vector2>().y;

    }

    void FixedUpdate()
    {  
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
