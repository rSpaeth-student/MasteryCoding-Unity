using UnityEngine;

public class Car : MonoBehaviour
{
    private float driveAxis, brakeAxis, turnAxis;

    // Drive - a public method which takes in an axis value from the player
    // and stores that value to be used later to control forward / backward
    // movement.
    public void Drive(float driveAxis)
    {
        this.driveAxis = Mathf.Clamp(driveAxis, -1f, 1f);
    }

    // Brake - a public method which takes in an axis value from the player
    // and stores that value to be used later to control braking.
    public void Brake(float brakeAxis)
    {
        this.brakeAxis = Mathf.Clamp(brakeAxis, 0f, 1f);
    }

    // Turn - a public method which takes in an axis value from the player
    // and stores that value to be used later to control turning.
    public void Turn(float turnAxis)
    {
        this.turnAxis = Mathf.Clamp(turnAxis, -1f, 1f);
    }
}
