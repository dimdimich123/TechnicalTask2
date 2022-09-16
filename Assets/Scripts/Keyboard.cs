using UnityEngine;

/// <summary>
/// Controls the character using the keyboard.
/// </summary>
/// <remarks>
/// Moving a character with using virtual horizontal axis.
/// </remarks>
public class Keyboard : Control
{
    private float _x = 0;
    private Vector3 _direction = new Vector3(0, 0, 0);

    private void Update()
    {
        _x = Input.GetAxis("Horizontal");
        if(_x != 0)
        {
            _direction.x = _x;
            Player.StartMoving(_direction);
        }
    }
}
