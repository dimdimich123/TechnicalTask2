using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Character control using Swipe.
/// </summary>
/// <remarks>
/// Swiping left / right / - the character moved a discrete amount unimeters.
/// </remarks>
public class Swipe : Control, IPointerUpHandler, IPointerDownHandler
{
    private const float _minScreenDistanceInPercent = 10f;
    private const float _minScreenDistanceXInPercent = 7.5f;
    private const float _moveDistance = 1.5f;

    private float _minDistance = 100f;
    private float _minDistanceX = 75f;
    
    private float _pressPositionX = 0;
    private Vector3 _direction = new Vector3(0, 0, 0);

    private void Awake()
    {
        _minDistanceX = Camera.main.scaledPixelWidth / _minScreenDistanceXInPercent;
        _minDistance = Camera.main.scaledPixelWidth / _minScreenDistanceInPercent;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressPositionX = eventData.pressPosition.x;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        float distanceX = eventData.position.x - _pressPositionX;

        if (Mathf.Abs(distanceX) >= _minDistanceX &&
            (eventData.pressPosition - eventData.position).sqrMagnitude >= _minDistance * _minDistance)
        {
            _direction.x = distanceX < 0 ? -_moveDistance : _moveDistance;
            Player.StartMoving(_direction);
        }
    }
}
