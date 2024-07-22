using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityAction Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player character))
        {
            Collected?.Invoke();
            Destroy(gameObject);
        }
    }
}