using UnityEngine;

public class MedKit : Item
{
    [SerializeField] private int _health;

    public int Health => _health;
}