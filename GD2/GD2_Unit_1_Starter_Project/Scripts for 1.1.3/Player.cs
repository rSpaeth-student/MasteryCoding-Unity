using UnityEngine;

public class Player : MonoBehaviour
{
    public Car car; // reference to the controlled car script

    // Update is called once per frame
    private void Update()
    {
        // In Update - get input from Input class using GetAxis
        // pass update to Car script using the available public methods.

        // Example: car.Drive(Input.GetAxis("Vertical"));

        if (!car) return;

        car.Drive(Input.GetAxisRaw("Vertical"));
        car.Turn(Input.GetAxisRaw("Horizontal"));
        car.Brake(Input.GetKey(KeyCode.LeftShift) ? 1f : 0f);
    }
}
