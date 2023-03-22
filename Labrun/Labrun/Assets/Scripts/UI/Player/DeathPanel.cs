using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Button _respawnButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _panel;

    private void Awake()
    {
        _respawnButton.onClick.AddListener(ToRespawn);
        _menuButton.onClick.AddListener(ToMenu);
        _playerStats.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        _panel.SetActive(true);
    }
    private void ToRespawn()
    {
        SceneManager.LoadScene(1);
    }
    private void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
