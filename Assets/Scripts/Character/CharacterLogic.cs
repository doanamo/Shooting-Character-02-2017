using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    [HideInInspector]
    public CharacterController controller;

    [HideInInspector]
    public Animator animator;

    private void Start()
    {
        this.controller = GetComponent<CharacterController>();
        this.animator = GetComponent<Animator>();
    }

    public void Move(Vector3 direction)
    {
        // Set character's animator parameters.
        this.animator.SetBool(CharacterHash.Moving, direction != Vector3.zero);
        this.animator.SetFloat(CharacterHash.MovementX, direction.x, 0.15f, Time.fixedDeltaTime);
        this.animator.SetFloat(CharacterHash.MovementZ, direction.z, 0.15f, Time.fixedDeltaTime);
    }

    public void Run()
    {
        // Set character's animator parameters.
        this.animator.SetBool(CharacterHash.Running, true);
    }

    public void Aim(Vector3 direction)
    {
        // Set character's animator parameters.
        this.animator.SetBool(CharacterHash.Aiming, direction != Vector3.zero);
        this.animator.SetFloat(CharacterHash.AimingX, direction.x, 0.1f, Time.fixedDeltaTime);
        this.animator.SetFloat(CharacterHash.AimingZ, direction.z, 0.1f, Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        // Apply gravity to the character controller.
        this.controller.Move(Physics.gravity * 0.1f * Time.fixedDeltaTime);
    }

    public void LateUpdate()
    {
        // Reset character's animator paremeters.
        this.animator.SetBool(CharacterHash.Moving, false);
        this.animator.SetBool(CharacterHash.Running, false);
        this.animator.SetBool(CharacterHash.Aiming, false);
    }
}
