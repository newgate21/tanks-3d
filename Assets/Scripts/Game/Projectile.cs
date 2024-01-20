using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float ProjectileSpeed = 20;

    private Vector3 velocity;
    private Rigidbody rigidBody;
    private CollisionDetector collisionDetector;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        if (collisionDetector = GetComponent<CollisionDetector>())
        {
            // Subscribe to the collision event
            collisionDetector.OnCollisionEnterEvent += OnCollisionHandler;
        }
    }

    private void Update()
    {
        velocity = rigidBody.velocity;
    }

    void OnCollisionHandler(Collision _collision)
    {
        if (_collision.gameObject.CompareTag("Wall") || 
            _collision.gameObject.CompareTag("Block"))
        {
            Bounce(_collision);
        }
    }

    public void Bounce(Collision _collision)
    {
        // Check if the projectile has a Rigidbody component
        if (rigidBody == null) return;

        if (_collision.contactCount <= 0) return;

        // Apply the reflected velocity to the object
        rigidBody.velocity = Vector3.Reflect(velocity, _collision.GetContact(0).normal);
    }

    public void Fire(Vector3 _direction)
    {
        // Check if the projectile has a Rigidbody component
        if (rigidBody == null) return;

        // Apply force to shoot the projectile
        rigidBody.AddForce(_direction * ProjectileSpeed, ForceMode.Impulse);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the collision event
        collisionDetector.OnCollisionEnterEvent -= OnCollisionHandler;
    }
}
