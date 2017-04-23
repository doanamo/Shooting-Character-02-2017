using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    public GameObject weapon;
    private Vector3 movementDirection;

    public CharacterController controller
    {
        get; private set;
    }

    public Animator animator
    {
        get; private set;
    }

    private void Start()
    {
        this.controller = GetComponent<CharacterController>();
        this.animator = GetComponent<Animator>();
    }

    public void Move(Vector3 direction)
    {
        // Set state machine parameter.
        this.animator.SetBool(CharacterHashes.Moving, direction != Vector3.zero);

        // Save desired movement direction to update later.
        this.movementDirection = direction;
    }

    public void Run()
    {
        // Set character's animator parameters.
        this.animator.SetBool(CharacterHashes.Running, true);
    }

    public void Aim(Vector3 direction)
    {
        // Set character's animator parameters.
        this.animator.SetBool(CharacterHashes.Aiming, direction != Vector3.zero);
        this.animator.SetFloat(CharacterHashes.AimingX, direction.x, 0.1f, Time.fixedDeltaTime);
        this.animator.SetFloat(CharacterHashes.AimingZ, direction.z, 0.1f, Time.fixedDeltaTime);
    }

    private void Update()
    {
        // Update movement direction parameters.
        if (this.animator.GetBool(CharacterHashes.Moving))
        {
            this.animator.SetFloat(CharacterHashes.MovementX, this.movementDirection.x, 0.15f, Time.deltaTime);
            this.animator.SetFloat(CharacterHashes.MovementZ, this.movementDirection.z, 0.15f, Time.deltaTime);
        }
        else
        {
            this.animator.SetFloat(CharacterHashes.MovementX, 0.0f, 0.15f, Time.deltaTime);
            this.animator.SetFloat(CharacterHashes.MovementZ, 0.0f, 0.15f, Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        // Apply gravity to the character controller.
        this.controller.Move(Physics.gravity * 0.1f * Time.fixedDeltaTime);
    }

    public void LateUpdate()
    {
        // Reset character's animator paremeters.
        this.animator.SetBool(CharacterHashes.Moving, false);
        this.animator.SetBool(CharacterHashes.Running, false);
        this.animator.SetBool(CharacterHashes.Aiming, false);
    }
}
