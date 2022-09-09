using UnityEngine;

public class Keyboard : Control
{
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if(x != 0)
        {
            _player.StartMoving(new Vector3(x, 0, 0));
        }
    }
}
