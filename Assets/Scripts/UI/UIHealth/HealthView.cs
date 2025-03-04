using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= ChangeValue;
    }

    protected virtual void ChangeValue() { }
}