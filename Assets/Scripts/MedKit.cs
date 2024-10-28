using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _health;

    public void Collect(Player player)
    {
        player.Heal(_health);
        Destroy(gameObject);
    }
}