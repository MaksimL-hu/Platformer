using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject _objectToDestroy;

    protected virtual void DestroyObject()
    {
        Destroy(_objectToDestroy);
    }
}