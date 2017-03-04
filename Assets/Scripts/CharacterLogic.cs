using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    [HideInInspector]
    public CharacterController controller;

    [HideInInspector]
    public Animator animator;

    private readonly int HashMoving = Animator.StringToHash("Moving");
    private readonly int HashMovementX = Animator.StringToHash("Movement X");
    private readonly int HashMovementZ = Animator.StringToHash("Movement Z");

    private void Start()
    {
        this.controller = GetComponent<CharacterController>();
        this.animator = GetComponent<Animator>();
    }

    public void Move(Vector3 direction)
    {
        // Set character's animator parameters.
        this.animator.SetBool(HashMoving, direction != Vector3.zero);
        this.animator.SetFloat(this.HashMovementX, direction.x, 0.15f, Time.fixedDeltaTime);
        this.animator.SetFloat(this.HashMovementZ, direction.z, 0.15f, Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        // Apply gravity to the character controller.
        this.controller.Move(Physics.gravity * Time.fixedDeltaTime);
    }
}
