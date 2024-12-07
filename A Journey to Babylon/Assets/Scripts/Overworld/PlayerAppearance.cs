using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAppearance : MonoBehaviour
{
    [SerializeField] SpriteRenderer Sprite;
    private InputAction MoveAction;

    void Start()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
    }
    void Update()
    {
        //flip when walking
        if(MoveAction.ReadValue<Vector2>().x < 0)
        {
            Sprite.flipX = true;
        }
        else if(MoveAction.ReadValue<Vector2>().x > 0)
        {
            Sprite.flipX = false;
        }
    }
}
