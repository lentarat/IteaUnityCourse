using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SeekPlayer : MonoBehaviour
{
    private Light2D _light;
    private Transform _playerPosition;
    private void Awake()
    {
        _light = gameObject.GetComponentInChildren<Light2D>();
        _playerPosition = FindObjectOfType<PlayerMovement>().transform;
    }
    public bool PlayerIsFound()
    {
        if (Vector2.Distance(_playerPosition.position, transform.position) < _light.pointLightOuterRadius &&
            Vector2.Angle((_playerPosition.position - transform.position).normalized, -transform.right) < 30f)
        {
            return true;
        }
        return false;
    }
}