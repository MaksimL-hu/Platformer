using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderVampirism : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private VampirismAbility _vampirism;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _vampirism.OnStealingHealth += Remove;
        _vampirism.OnReloading += Fill;
    }

    private void OnDisable()
    {
        _vampirism.OnStealingHealth -= Remove;
        _vampirism.OnReloading -= Fill;
    }

    private void Fill()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangingValue(_slider.maxValue, _vampirism.ReloadVampirism));
    }

    private void Remove()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangingValue(_slider.minValue, _vampirism.TimeAttackVampirism));
    }

    private IEnumerator ChangingValue(float end, float timeSmooth)
    {
        float start = _slider.value;
        float time = 0f;

        while (time < timeSmooth)
        {
            time += Time.deltaTime;

            _slider.value = Mathf.Lerp(start, end, time / timeSmooth);

            yield return null;
        }

        _slider.value = end;
    }
}