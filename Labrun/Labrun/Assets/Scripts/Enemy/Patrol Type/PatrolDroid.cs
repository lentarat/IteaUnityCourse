using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PatrolDroid : MonoBehaviour
{
    [SerializeField] private Transform _gunTransform;
    [SerializeField] private GameObject _projectile;
    private Droid3Animations _droid3Animations = new Droid3Animations();
    private AnimationController _animationController;
    private SeekPlayer _seekPlayer;
    private bool _playerIsFound;
    private bool _finishedShooting = true;
    private void SetFinishedShooting() { _finishedShooting = true; }
    MoveBetweenPoints _moveBetweenPoints;
  

    private void Awake()
    {
        _moveBetweenPoints = GetComponent<MoveBetweenPoints>();
        _animationController = GetComponent<AnimationController>();
        _seekPlayer = gameObject.GetComponent<SeekPlayer>();
    }
    public void Patrol()
    {
        if (_seekPlayer.PlayerIsFound())
        {
            if (_finishedShooting)
            {
                _animationController.ChangeAnimationState(_droid3Animations.CountdownAnimation);
                _finishedShooting = false;
            }
        }
        else
        {
            _animationController.ChangeAnimationState(_droid3Animations.MoveAnimation);
            _finishedShooting = true;
            _moveBetweenPoints.Move();
        }
    }
    private void Attack()
    {
        _animationController.ChangeAnimationState(_droid3Animations.AttackAnimation);
    }
    private void Shoot()
    {
        Instantiate(_projectile,_gunTransform.position,Quaternion.identity);
    }

}