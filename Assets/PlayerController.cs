using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private NewControls playerInput;

    void Awake()
    {
        playerInput = new NewControls();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnanble()
    {
        playerInput.Enable();
    }
    
    private void OnDisable()
    {
        playerInput.Disable();
    }

    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private float playerSpeed = 2.0f;

    void Update()
    {
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector2 move = new Vector2(movementInput.x, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector2.zero)
        {
            gameObject.transform.forward = move;
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
