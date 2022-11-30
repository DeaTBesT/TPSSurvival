using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string animMoveX = "MoveX";
    private const string animMoveZ = "MoveZ";

    public void AnimMove(float moveX, float moveZ)
    {
        _animator.SetFloat(animMoveX, moveX);
        _animator.SetFloat(animMoveZ, moveZ);
    }
}
