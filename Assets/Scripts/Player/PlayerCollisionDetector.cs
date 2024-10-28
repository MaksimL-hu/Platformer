using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Collect();
            _coinSpawner.SpawnCoin();
        }

        if (collision.gameObject.TryGetComponent<MedKit>(out MedKit medKit))
        {
            medKit.Collect(_player);
        }
    }
}