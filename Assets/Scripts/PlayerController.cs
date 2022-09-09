using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private MenuController _menu;

    private void OnEnable()
    {
        _menu.OnToggleChange += ChangeControl;
    }

    private void ChangeControl(Type type)
    {
        Destroy(GetComponent<Control>());
        ((Control)gameObject.AddComponent(type)).SetPlayer(_player);
    }

    private void OnDisable()
    {
        _menu.OnToggleChange -= ChangeControl;
    }
}
