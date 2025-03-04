using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private GameObject _sprite;
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;

    private void Update()
    {
        if(_inputReader.Direction > 0)
            _sprite.transform.localScale = new Vector3(Math.Abs(_sprite.transform.localScale.x), _sprite.transform.localScale.y, _sprite.transform.localScale.z);
        else if(_inputReader.Direction < 0 && transform.localScale.x > 0)
            _sprite.transform.localScale = new Vector3(-_sprite.transform.localScale.x, _sprite.transform.localScale.y, _sprite.transform.localScale.z);

        _animator.SetFloat(AnimatorConstants.Speed, Math.Abs(_inputReader.Direction));
    }

    public void PlayJumpAnimation()
    {
        _animator.SetTrigger(AnimatorConstants.Jump);
    }
}