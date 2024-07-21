using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private Checker _groundCkecker;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Constants.Space) && _groundCkecker.IsCollision)
            Jump();

        float direction = Input.GetAxis(Constants.Horizontal);

        if (direction == 0)
        {
            _animator.SetBool(AnimatorConstants.Move, false);
            return;
        }
        else if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        _animator.SetBool(AnimatorConstants.Move, true);
        transform.position += new Vector3(direction * _speed * Time.deltaTime, 0, 0);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce);
        _animator.SetTrigger(AnimatorConstants.Jump);
    }
}