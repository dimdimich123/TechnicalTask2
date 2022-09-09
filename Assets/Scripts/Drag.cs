using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : Control, IDragHandler, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler
{
    private bool _isOutsideUI = true;

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
        Vector3 direction = new Vector3(pointerWorldPositionX - _player.gameObject.transform.position.x, 0, 0);
        _player.StartMoving(direction);
    }
}
