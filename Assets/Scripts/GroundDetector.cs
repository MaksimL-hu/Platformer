using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private int _count = 0;

    public bool IsGround => _count > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            _count += 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            _count -= 1;
    }
}