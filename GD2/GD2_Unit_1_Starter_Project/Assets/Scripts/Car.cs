using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Car : MonoBehaviour
{
    #region Data
    private Rigidbody rigidbody; //Rigidbody to apply forces to 
    private float driveAxis, brakeAxis, turnAxis; //save valid input values from public interface
    public bool grounded = false;

    [Header("Suspension")] //Header attribute allows us to specify that everything in this section 
                           //belongs to Suspension.
    [SerializeField] List<Transform> wheels; // Wheel Transforms - each transform represents the center of a wheel
                                            // used during suspension raycasts

    [Tooltip("Radius used for wheel raycasts.")]
    [Range(0.1f, 1f)]
    [SerializeField] float wheelRadius = 0.4f; // The radius of each wheel - used to determine the max distance
                                            // of each raycast

    [Tooltip("Spring force constant k. Applies upwards spring force proportional to wheel vertical offset.")]
    [Range(50f, 250f)]
    [SerializeField] float springStrength = 100f;

    [Tooltip("Spring damping value. Damps spring force proportional to point velocity.")]
    [Range(1f, 5f)]
    [SerializeField] float springDamping = 3f; // Whether or not our car is on the ground.

    [Header("Acceleration")]

    [Tooltip("Max longitudinal force output. Force output is proportional to (1 - (currentSpeed / maxSpeed)).")]
    [Range(15f, 35f)]
    [SerializeField] float maxSpeed = 25f;

    [Header("Friction")]

    [Tooltip("Longitudinal friction coefficient. Used to apply oppositional longitudinal force proportional to velocity.")]
    [Range(1f, 5f)]
    [SerializeField] float longitudinalFriction = 2f; // The friction coefficient for forward / backward momentum.
                                                    // Higher values will result in stopping more quickly when not applying 
                                                    // forward / backward drive input.

    [Tooltip("Lateral friction coefficient. Used to apply oppositional lateral force proportional to velocity.")]
    [Range(1f, 5f)]
    [SerializeField] float lateralFriction = 2f; // The friction coefficient for left / right momentum
                                                // Higher values will result in less sliding left / right

    [Header("Stearing")]

    [Tooltip("Turn angle for wheels.")]
    [Range(10, 45)]
    [SerializeField] float steeringAngle = 30f; // The angle used to steer / add torque to the car - higher angles
                                                // will reuslt in faster turning

    [Tooltip("Damping coefficient for Y-axis rotational velocity")]
    [Range(1f, 10f)]
    [SerializeField] float turnDamping = 5f;

    #endregion

    #region Public Interface
    /*
        Accepts and validates external drive input.
        Clamps driveAxis between -1 and 1.
    */

    // Drive - a public method which takes in an axis value from the player
    // and stores that value to be used later to control forward / backward
    // movement.
    public void Drive(float driveAxis)
    {
        this.driveAxis = Mathf.Clamp(driveAxis, -1f, 1f);
    }

    /*
        Accepts and validates external braking input.
        Clamps brakeAxis between 0 and 1.
    */
    public void Brake(float brakeAxis)
    {
        this.brakeAxis = Mathf.Clamp(brakeAxis, 0f, 1f);
    }

    /*
        Accepts and validates external turn input.
        Clamps turn axis between -1 and 1.
    */
    public void Turn(float turnAxis)
    {
        this.turnAxis = Mathf.Clamp(turnAxis, -1f, 1f);
    }
    public bool GetGrounded() => grounded;

    #endregion

    #region MonoBehaviour Life Cycle
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ApplySuspenspionForce();
        if (!grounded) return;
        // We'll add more forces here later
        // but these forces only apply if the
        // car is on the ground.
        ApplyLongitudinalForce();
        ApplyLateralForce();
        ApplyTurningForce();
    }
    #endregion

    #region Forces
    private void ApplySuspenspionForce()
    {
        // Detect whether or not any wheel is touching the ground.
        bool tempGrounded = false;
        // For each wheel raycast down and detect a ground hit.
        foreach (Transform wheel in wheels)
        {
            Vector3 origin = wheel.position;
            Vector3 direction = -wheel.up;
            RaycastHit hit;
            float offset = 0f;

            if (Physics.Raycast(origin, direction, out hit, wheelRadius))
            {
                // If this raycast returns true it means that this wheel has hit the ground.
                tempGrounded = true;

                Vector3 end = origin + (direction * wheelRadius);
                offset = (end - hit.point).magnitude;

                float pointVelocity = Vector3.Dot(wheel.up, rigidbody.GetPointVelocity(wheel.position));
                float suspensionForce = (springStrength * offset) + (-pointVelocity * springDamping);
                rigidbody.AddForceAtPosition(wheel.up * suspensionForce, wheel.position);
            }
        }
        // Update grounded with tempGrounded value
        grounded = tempGrounded;
    }

    private void ApplyLongitudinalForce()
    {
        // The force vector used to add force to the rigid body
        Vector3 force = Vector3.zero;
        // How fast the car is currently traveling along its own forward axis
        float forwardVelocity = Vector3.Dot(transform.forward, rigidbody.velocity);
        // An inverted ratio of current forward velocity compared against max speed
        // If forward velocity is equal to max speed this ratio will equate to 1 - 1, 
        // resulting in no additional force added
        // If forward velocity is equal to 0, this ratio will equate to 1 - 0, resulting in full
        // force added.
        float maxSpeedRatio = (1 - (Mathf.Abs(forwardVelocity) / maxSpeed));

        // If the player wants to travel either forward or backward this 
        // axis will either be greater than or less than 0
        if (Mathf.Abs(driveAxis) > 0)
        {
            // Force is equivalent to drive input * max speed * ratio of forward velocity to max speed
            force = transform.forward * driveAxis * maxSpeed * maxSpeedRatio;
        }
        else
        {
            // Apply braking / friciton force equivalent to the opposite of velocity * friction coefficient
            force = transform.forward * -forwardVelocity * longitudinalFriction;
        }

        rigidbody.AddForce(force);
    }
    private void ApplyLateralForce()
    {
        // Get the current lateral velocity of the car's rigidbody.
        // Use Vector3.Dot() to get the dot product of the car transform's right axis and the
        // rigidbody's velocity

        float rightVelocity = Vector3.Dot(transform.right, rigidbody.velocity);

        // Add force to the rigidbody in the opposite direction of it's current lateral velocity
        // This should include a class data member called lateralFriction
        // acting as the friction coefficient\

        rigidbody.AddForce(transform.right * -rightVelocity * lateralFriction);

    }

    private void ApplyTurningForce()
    {
        float forwardVelocity = Vector3.Dot(transform.forward, rigidbody.velocity);
        float rotationalVelocity = Vector3.Dot(transform.up, rigidbody.angularVelocity); //measures the upwards direction of the car

        Vector3 rotationAxis = transform.up;
        float torque = forwardVelocity * turnAxis * (Mathf.Deg2Rad * steeringAngle);
        torque += -rotationalVelocity * turnDamping;

        rigidbody.AddTorque(rotationAxis * torque);
    }
    #endregion
}
