using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private void Update()
    {
        if (GameController.Instance.IsPlayActive())
        {
            ManageMenuCommands();
            ManagePlayerCommands();
        }
    }
    private void ManageMenuCommands()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameController.Instance.GoToState(GameController.eGameState.PauseGame);
        }
    }
    private void ManagePlayerCommands()
    {
        CheckPlayerMovement();
        CheckPlayerFire();
    }
    private void CheckPlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GameController.Instance.Player.Move(1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GameController.Instance.Player.Move(-1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GameController.Instance.Player.Rotate(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GameController.Instance.Player.Rotate(1);
        }
    }
    private void CheckPlayerFire()
    {
        if (Input.GetMouseButton(0))
        {
            GameController.Instance.Player.Fire();
        }
    }
}
