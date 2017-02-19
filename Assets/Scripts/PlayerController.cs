using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterLogic character;

    void FixedUpdate()
    {
        // Create a movement vector from the input.
        // Todo: Implement smooth direction change.
        Vector3 movementDirection = Vector3.zero;
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.z = Input.GetAxis("Vertical");
        movementDirection.Normalize();

        // Send a character move command.
        if(movementDirection != Vector3.zero)
        {
            MoveCommand command = new MoveCommand();
            command.direction = movementDirection;
            this.character.HandleMessage(command);
        }
    }
}
