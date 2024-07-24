using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputReader _inputReader;

    private void Update()
    {
        if(_inputReader.Direction > 0)
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if(_inputReader.Direction < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        _animator.SetFloat(AnimatorConstants.Speed, Math.Abs(_inputReader.Direction));
    }

    public void PlayJumpAnimation()
    {
        _animator.SetTrigger(AnimatorConstants.Jump);
    }
}