using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterLogic character;

    void Update()
    {
        // Calculate desired movement direction.
        Vector3 movementDirection = Vector3.zero;
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.z = Input.GetAxis("Vertical");
        movementDirection.Normalize();

        // Calculate desired aiming direction.
        Vector3 aimingDirection = Vector3.zero;

        if(Input.GetMouseButton(1))
        {
            // Create a plane positioned at the character's feet and cast a ray onto it.
            Plane plane = new Plane(new Vector3(0.0f, 1.0f, 0.0f), this.character.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Cast the ray against the plane.
            float rayDistance = 0.0f;

            if(plane.Raycast(ray, out rayDistance))
            {
                // Calculate ray direction from character's position.
                aimingDirection = (ray.GetPoint(rayDistance) - this.character.transform.position).normalized;
            }
        }

        // Handle character's running.
        this.character.Move(movementDirection != Vector3.zero, movementDirection);

        // Handle character's running.
        this.character.Run(Input.GetKey(KeyCode.LeftShift));

        // Handle character's aiming.
        this.character.Aim(aimingDirection != Vector3.zero, aimingDirection);

        // Handle character's shooting.
        this.character.Shoot(Input.GetMouseButton(0));
    }
}
