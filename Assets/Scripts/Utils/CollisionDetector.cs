using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Define a delegate type for collision events
    public delegate void CollisionEventHandler(Collision other);

    // Define events based on the delegate
    public event CollisionEventHandler OnCollisionEnterEvent;

    private void OnCollisionEnter(Collision collision)
    {
        // Trigger the event when a collision occurs
        OnCollisionEnterEvent?.Invoke(collision);
    }
}