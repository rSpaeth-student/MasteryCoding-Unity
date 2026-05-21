using UnityEngine;
using UnityEngine.Events;


public class Checkpoint : MonoBehaviour
{
    bool checkpointEnabled = false;
    public static UnityEvent<Checkpoint, GameObject> OnCheckpointPassed = new UnityEvent<Checkpoint, GameObject>();
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (!checkpointEnabled) return;

        if (other.gameObject.CompareTag("Car"))
        {
            OnCheckpointPassed.Invoke(this, other.attachedRigidbody.gameObject);
            //checkpointEnabled = false;
            SetCheckpointEnabled(false);
        }

    }
    public void SetCheckpointEnabled(bool newValue) => animator.SetBool("Checkpoint Enabled", (checkpointEnabled = newValue));
}
