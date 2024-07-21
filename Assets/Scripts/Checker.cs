using UnityEngine;

public class Checker : MonoBehaviour
{
    public bool IsCollision { get; private set; }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsCollision = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsCollision = true;
    }
}