using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderHealth : SliderHealth
{
    [SerializeField] private float _timeSmooth;

    private Coroutine _coroutine;

    protected override void ChangeValue()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangingValue());
    }

    private IEnumerator ChangingValue()
    {
        float start = Slider.value;
        float end = Health.CurrentHealth / Health.MaxHealth;
        float time = 0f;

        while (time < _timeSmooth)
        {
            time += Time.deltaTime;

            Slider.value = Mathf.Lerp(start, end, time / _timeSmooth);

            yield return null;
        }

        Slider.value = end;
    }
}