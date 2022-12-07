using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string animMoveX = "MoveX";
    private const string animMoveZ = "MoveZ";
    private const string state = "State";

    public void SetState(float _value)
    {
        _animator.SetFloat(state, _value);
    }

    public void AnimMove(float moveX, float moveZ)
    {
        _animator.SetFloat(animMoveX, moveX);
        _animator.SetFloat(animMoveZ, moveZ);
    }
}
