using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterLogic character;

    void Update()
    {
        // Handle directional input for character movement.
        Vector3 movementDirection = Vector3.zero;
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.z = Input.GetAxis("Vertical");
        movementDirection.Normalize();

        if(movementDirection != Vector3.zero)
        {
            // Move with the controlled character.
            this.character.Move(movementDirection);
        }

        // Handle right mouse button input for character aiming.
        if(Input.GetMouseButton(1))
        {
            // Create a plane positioned at the character's feet.
            Plane plane = new Plane(new Vector3(0.0f, 1.0f, 0.0f), this.character.transform.position);

            // Create a ray from the screen to world.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Cast the ray against the plane.
            float rayDistance = 0.0f;

            if(plane.Raycast(ray, out rayDistance))
            {
                // Calculate ray direction from character's position.
                Vector3 position = ray.GetPoint(rayDistance);
                Vector3 direction = position - this.character.transform.position;
                direction.Normalize();

                // Move with the controlled character.
                this.character.Aim(direction);
            }
        }
    }
}
