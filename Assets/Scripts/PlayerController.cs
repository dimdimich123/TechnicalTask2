using UnityEngine;
using System;

/// <summary>
/// Stores and changes the type of character control.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private PauseMenuView _pauseMenu;

    private void OnEnable()
    {
        _pauseMenu.OnChangeControl += ChangeControl;
    }

    private void ChangeControl(Type type)
    {
        Destroy(GetComponent<Control>());
        ((Control)gameObject.AddComponent(type)).SetPlayer(_player);
    }

    private void OnDisable()
    {
        _pauseMenu.OnChangeControl -= ChangeControl;
    }
}
