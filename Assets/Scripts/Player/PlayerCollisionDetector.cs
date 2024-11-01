using System;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private Player _player;

    public event Action<int> MedKitCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Item>(out Item item))
        {
            if(item is Coin)
            {
                item.Collect();
                _coinSpawner.SpawnCoin();
            }
            else if(item is MedKit medKit)
            {
                item.Collect();
                MedKitCollected?.Invoke(medKit.Health);
            }
        }
    }
}