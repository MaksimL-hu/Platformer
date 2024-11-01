using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const int LeftMouseButton = 0;
    public const KeyCode Space = KeyCode.Space;

    private bool _isJump;
    private bool _isAttack;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(Space))
            _isJump = true;

        if (Input.GetMouseButtonDown(LeftMouseButton))
            _isAttack = true;
    }

    public bool GetIsJump() => 
        GetBoolAsTrigger(ref _isJump);

    public bool GetIsAttack() => 
        GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}