using System.Collections;
using UnityEngine;

/// <summary>
/// Carries out the movement of the character in world space.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private const float _radiusToBorder = 6f;
    private const float _delta = 0.001f;
    private const float _factor = 4f;

    private Transform _transform;
    private Vector3 _tergetPoint;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void StartMoving(Vector3 direction)
    {
        StopAllCoroutines();
        StartCoroutine(Move(direction));
    }

    private IEnumerator Move(Vector3 direction)
    {
        _tergetPoint = Mathf.Abs(_transform.position.x + direction.x) <= _radiusToBorder ?
            _transform.position + direction : new Vector3(_radiusToBorder * direction.normalized.x, 0, 0);

        while ((_transform.position - _tergetPoint).sqrMagnitude > _delta * _delta)
        {
            _transform.position = Vector3.Lerp(_transform.position, _tergetPoint, Time.deltaTime * _factor);
            yield return null;
        }

    }
}
