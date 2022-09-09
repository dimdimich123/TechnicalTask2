using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float _radiusToBorder = 6f;
    private const float _delta = 0.001f;
    private const float _factor = 4f;

    public void StartMoving(Vector3 direction)
    {
        StopAllCoroutines();
        StartCoroutine(Move(direction));
    }

    private IEnumerator Move(Vector3 direction)
    {
        Vector3 tergetPoint = Mathf.Abs(transform.position.x + direction.x) <= _radiusToBorder ? 
            transform.position + direction : new Vector3(_radiusToBorder * direction.normalized.x, 0, 0);

        while ((transform.position - tergetPoint).sqrMagnitude > _delta * _delta)
        {
            transform.position = Vector3.Lerp(transform.position, tergetPoint, Time.deltaTime * _factor);
            yield return null;
        }

    }
}
