using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : BaseTank
{
    public void Move(int _sign)
    {
        transform.Translate(Mathf.Sign(_sign) * transform.forward * moveSpeed * Time.deltaTime, Space.World);
    }
    public void Rotate(int _sign)
    {
        transform.Rotate(Vector3.up, Mathf.Sign(_sign) * rotateSpeed * Time.deltaTime);
    }
    protected override void OnHit()
    {
        if (currentHealth <= 0)
        {
            GameController.Instance.OnPlayerDestroyed();
        }
        base.OnHit();
    }
}
