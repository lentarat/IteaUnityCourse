using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SeekPlayer : MonoBehaviour
{
    private Light2D _light;
    //private Transform _playerPosition;
    private PlayerStats _playerStats;
    private void Awake()
    {
        _light = gameObject.GetComponentInChildren<Light2D>();
        _playerStats = FindObjectOfType<PlayerStats>();
    }
    public bool PlayerIsFound()
    {
        if (_playerStats.Health > 0f && Vector2.Distance(_playerStats.transform.position, transform.position) < _light.pointLightOuterRadius &&
            Vector2.Angle((_playerStats.transform.position - transform.position).normalized, -transform.right) < 30f)
        {
            return true;
        }
        return false;
    }
}