using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Controls the character using drag.
/// </summary>
/// <remarks>
/// The user moves a finger or cursor across the screen - the character tends to drag positions.
/// </remarks>
public class Drag : Control, IDragHandler, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler
{
    private bool _isOutsideUI = true;
    private Vector3 _direction = new Vector3(0, 0, 0);

    public void OnDrag(PointerEventData eventData)
    {
        if (_isOutsideUI)
        {
            MovePlayer(eventData.pointerCurrentRaycast.worldPosition.x);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_isOutsideUI)
        {
            MovePlayer(eventData.pointerCurrentRaycast.worldPosition.x);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isOutsideUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isOutsideUI = false;
    }

    private void MovePlayer(float pointerWorldPositionX)
    {
        _direction.x = pointerWorldPositionX - Player.gameObject.transform.position.x;
        Player.StartMoving(_direction);
    }
}
