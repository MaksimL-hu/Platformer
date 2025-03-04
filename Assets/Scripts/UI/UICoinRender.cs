using TMPro;
using UnityEngine;

public class UICoinRender : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private PlayerCollisionDetector _player;

    private int _coinCount;

    private void OnEnable()
    {
        _player.CoinCollected += ChangeValue;
    }

    private void OnDisable()
    {
        _player.CoinCollected -= ChangeValue;
    }

    private void Start()
    {
        _coinCount = 0;
        RenderMessage();
    }

    private void ChangeValue()
    {
        _coinCount++;
        RenderMessage();
    }

    private void RenderMessage()
    {
        _text.text = "Coin collected: " + _coinCount;
    }
}