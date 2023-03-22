using UnityEngine;

public class PatrolDroid : MonoBehaviour
{
    [SerializeField] private Transform _gunTransform;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private SeekPlayer _seekPlayer;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] MoveBetweenPoints _moveBetweenPoints;
    [SerializeField] AudioManager _audioManager;

    private Droid3Animations _droid3Animations = new Droid3Animations();
    
    private bool _playerIsFound;
    private bool _finishedShooting = true;
    private void SetFinishedShooting() { _finishedShooting = true; }
  
    public void Patrol()
    {
        if (_seekPlayer.PlayerIsFound())
        {
            if (_finishedShooting)
            {
                _audioManager.Pause();
                _animationController.ChangeAnimationState(_droid3Animations.CountdownAnimation);
                _finishedShooting = false;
            }
        }
        else
        {
            _audioManager.Play("Move");
            _animationController.ChangeAnimationState(_droid3Animations.MoveAnimation);
            _finishedShooting = true;
            _moveBetweenPoints.Move();
        }
    }
    private void Attack()
    {
        //_audioManager.Play("Shoot");
        _animationController.ChangeAnimationState(_droid3Animations.AttackAnimation);
    }
    private void Shoot()
    {
        Instantiate(_projectile,_gunTransform.position,Quaternion.identity);
        _audioManager.Play("Shoot");
    }

}