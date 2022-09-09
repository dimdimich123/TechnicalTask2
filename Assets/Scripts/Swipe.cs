using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : Control, IPointerUpHandler, IPointerDownHandler
{
    private const float _minDistance = 100f;
    private const float _minDistanceX = 75f;
    private const float _moveDistance = 1.5f;

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float distanceX = eventData.position.x - eventData.pressPosition.x;

        if (Mathf.Abs(distanceX) >= _minDistanceX && 
            (eventData.pressPosition - eventData.position).sqrMagnitude >= _minDistance * _minDistance)
        {
            Vector3 direction = distanceX < 0 ? new Vector3(-_moveDistance, 0, 0) : new Vector3(_moveDistance, 0, 0);
            _player.StartMoving(direction);
        }
    }
}
