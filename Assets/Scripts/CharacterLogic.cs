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

    private readonly int HashAiming = Animator.StringToHash("Aiming");
    private readonly int HashAimingX = Animator.StringToHash("Aiming X");
    private readonly int HashAimingZ = Animator.StringToHash("Aiming Z");

    private void Start()
    {
        this.controller = GetComponent<CharacterController>();
        this.animator = GetComponent<Animator>();
    }

    public void Move(Vector3 direction)
    {
        // Set character's animator parameters.
        this.animator.SetBool(this.HashMoving, direction != Vector3.zero);
        this.animator.SetFloat(this.HashMovementX, direction.x, 0.15f, Time.fixedDeltaTime);
        this.animator.SetFloat(this.HashMovementZ, direction.z, 0.15f, Time.fixedDeltaTime);
    }

    public void Aim(Vector3 direction)
    {
        // Set character's animator parameters.
        this.animator.SetBool(this.HashAiming, direction != Vector3.zero);
        this.animator.SetFloat(this.HashAimingX, direction.x, 0.0f, Time.fixedDeltaTime);
        this.animator.SetFloat(this.HashAimingZ, direction.z, 0.0f, Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        // Apply gravity to the character controller.
        this.controller.Move(Physics.gravity * 0.1f * Time.fixedDeltaTime);
    }

    public void LateUpdate()
    {
        // Reset character's animator paremeters.
        this.animator.SetBool(this.HashMoving, false);
        this.animator.SetBool(this.HashAiming, false);
    }
}
