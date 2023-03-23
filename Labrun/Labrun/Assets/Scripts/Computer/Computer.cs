using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Computer : MonoBehaviour
{
    //[SerializeField] private string _words;
    //[SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _numericPanel;
    //private LayerMask _playerLayer;
    //private void Start()
    //{
    //    _playerLayer = LayerMask.NameToLayer("Player");
    //}

    private void OnTriggerStay2D(Collider2D collision)
{
    if (Input.GetKey(KeyCode.E))
    {
        _numericPanel.SetActive(true);
    }
}
}
