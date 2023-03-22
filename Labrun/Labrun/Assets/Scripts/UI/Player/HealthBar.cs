using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] PlayerStats _playerStats;
    private float _maxHealth;
    private void Awake()
    {
        _playerStats.OnDamageTaken += DisplayHealth;
        _maxHealth = _playerStats.Health;
    }
    private void DisplayHealth(float health)
    {
        _image.fillAmount = health / _maxHealth;
    }
}
