using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyTank : BaseTank
{
    protected float range = 2f;
    void Update()
    {
        Move();
        if (GameController.Instance.Player)
        {
            UpdateFiringDirection(GameController.Instance.Player.transform.position);
            Fire();
        }    
    }
    // Implement abstract methods
    protected virtual void Move()
    {
        float x = Mathf.PingPong(Time.time * moveSpeed, range * 2) - range;
        transform.Translate(Vector2.left * Time.deltaTime * x);
    }
}
