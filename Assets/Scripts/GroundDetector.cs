using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private int count = 0;

    public bool IsGround => count > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            count += 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out _))
            count -= 1;
    }
}