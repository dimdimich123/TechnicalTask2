using UnityEngine;

/// <summary>
/// Template class for creating character control options
/// </summary>
public abstract class Control : MonoBehaviour
{
    protected PlayerMovement Player;
    
    public void SetPlayer(PlayerMovement player) => Player = player;
}
