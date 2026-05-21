using UnityEngine;
using UnityEngine.Events;


public class BoundsVolume : MonoBehaviour
{
    public UnityEvent<Rigidbody> OnBoundsVolumeEnter;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            OnBoundsVolumeEnter?.Invoke(other.attachedRigidbody); //if there's nothing listening it won't invoke
        }
    }
}
