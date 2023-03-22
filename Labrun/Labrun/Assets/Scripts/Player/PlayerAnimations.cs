using UnityEngine;

public class PlayerAnimations
{ 
    // чи варто зробити цей клас static?
    public readonly int IdleAnimation = Animator.StringToHash("Idle");
    public readonly int WalkAnimation = Animator.StringToHash("Walk");
    public readonly int RunAnimation = Animator.StringToHash("Run");
    public readonly int JumpAnimation = Animator.StringToHash("Jump");
    public readonly int DuckDownAnimation = Animator.StringToHash("DuckDown");
    public readonly int DuckUpAnimation = Animator.StringToHash("DuckUp");
    public readonly int DisappearAnimation = Animator.StringToHash("Disappear");
    public readonly int DieAnimation = Animator.StringToHash("Die");
}
