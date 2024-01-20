using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTank : MonoBehaviour
{
    [SerializeField] protected short maxHealth;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float rotateSpeed;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float fireDelay;

    protected short currentHealth;
    protected Vector3 firingDirection;
    protected TimedDelayer delayerScript;
    private CollisionDetector collisionDetector;

    void Awake()
    {
        currentHealth = maxHealth;
        if (collisionDetector = GetComponent<CollisionDetector>())
        {
            // Subscribe to the collision event
            collisionDetector.OnCollisionEnterEvent += OnCollisionHandler;
        }
    }
    void Start()
    {
        delayerScript = GetComponent<TimedDelayer>();
    }
    void Update()
    {
        UpdateFiringDirection(MousePositionOnPlane.GetMousePositionOnPlaneXZ());
    }
    public void Reset()
    {
        currentHealth = maxHealth;
    }
    protected void UpdateFiringDirection(Vector3 _newFiringPosition)
    {
        // Calculate the direction vector from the current position to the firing position
        firingDirection = (_newFiringPosition - transform.position);
    }
    public void Fire()
    {
        if (projectilePrefab == null) return;
        if (delayerScript == null) return;

        // Check if firing too fast
        if (delayerScript.IsDelayInProgress) return;

        // Start the time delay for firing
        delayerScript.StartDelay(fireDelay);

        // Create a new projectile
        GameObject newProjectile = Instantiate<GameObject>(projectilePrefab, transform.position, transform.rotation, transform);
        newProjectile.transform.SetParent(null);

        // Trigger a firing action
        newProjectile.GetComponent<Projectile>().Fire(firingDirection.normalized);
    }
    void OnCollisionHandler(Collision _collision)
    {
        if (_collision.gameObject.CompareTag("Projectile"))
        {
            currentHealth--;
            OnHit();
        }
    }
    protected virtual void OnHit()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
