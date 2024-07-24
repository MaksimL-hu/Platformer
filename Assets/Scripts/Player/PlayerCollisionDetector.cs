using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Collect();
            _coinSpawner.SpawnCoin();
        }
    }
}
