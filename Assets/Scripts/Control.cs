using UnityEngine;

public abstract class Control : MonoBehaviour
{
    protected PlayerMovement _player;

    public void SetPlayer(PlayerMovement player) =>  _player = player;
}
