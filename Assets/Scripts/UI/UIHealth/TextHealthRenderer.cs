using TMPro;
using UnityEngine;

public class TextHealthRenderer : HealthView
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _gapSymbol;

    protected override void ChangeValue()
    {
        _text.text = Health.CurrentHealth + _gapSymbol + Health.MaxHealth;
    }
}