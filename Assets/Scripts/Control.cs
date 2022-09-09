using UnityEngine;

public abstract class Control : MonoBehaviour
{
    protected PlayerMovement Player;

    public void SetPlayer(PlayerMovement player) => Player = player;
}
