using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    public GameObject weapon;

    private Vector3 movementDirection;
    private Vector3 aimingDirection;

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

    public void Move(bool toggle, Vector3 direction)
    {
        this.animator.SetBool(CharacterHashes.Moving, toggle);
        this.movementDirection = direction;
    }

    public void Run(bool toggle)
    {
        this.animator.SetBool(CharacterHashes.Running, toggle);
    }

    public void Aim(bool toggle, Vector3 direction)
    {
        this.animator.SetBool(CharacterHashes.Aiming, toggle);
        this.aimingDirection = direction;
    }

    private void Update()
    {
        // Update movement direction parameters.
        if(this.animator.GetBool(CharacterHashes.Moving))
        {
            this.animator.SetFloat(CharacterHashes.MovementX, this.movementDirection.x, 0.15f, Time.deltaTime);
            this.animator.SetFloat(CharacterHashes.MovementZ, this.movementDirection.z, 0.15f, Time.deltaTime);
        }
        else
        {
            this.animator.SetFloat(CharacterHashes.MovementX, 0.0f, 0.15f, Time.deltaTime);
            this.animator.SetFloat(CharacterHashes.MovementZ, 0.0f, 0.15f, Time.deltaTime);
        }

        // Update aiming direction parameters.
        if(this.animator.GetBool(CharacterHashes.Aiming))
        {
            this.animator.SetFloat(CharacterHashes.AimingX, this.aimingDirection.x, 0.1f, Time.deltaTime);
            this.animator.SetFloat(CharacterHashes.AimingZ, this.aimingDirection.z, 0.1f, Time.deltaTime);
        }
        else
        {
            this.animator.SetFloat(CharacterHashes.AimingX, 0.0f, 0.1f, Time.deltaTime);
            this.animator.SetFloat(CharacterHashes.AimingZ, 0.0f, 0.1f, Time.deltaTime);
            this.animator.SetFloat(CharacterHashes.StrafingX, 0.0f, 0.1f, Time.deltaTime);
            this.animator.SetFloat(CharacterHashes.StrafingZ, 0.0f, 0.1f, Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        // Apply gravity to the character controller.
        this.controller.Move(Physics.gravity * 0.1f * Time.fixedDeltaTime);
    }
}
