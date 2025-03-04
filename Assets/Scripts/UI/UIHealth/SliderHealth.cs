using UnityEngine;
using UnityEngine.UI;

public class SliderHealth : HealthView
{
    [SerializeField] protected Slider Slider;

    protected override void ChangeValue()
    {
        Slider.value = Health.CurrentHealth / Health.MaxHealth;
    }
}