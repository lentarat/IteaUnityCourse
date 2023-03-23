using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System;

public class DisplayText : MonoBehaviour
{
    [SerializeField] private string _words;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private bool _destroyAfterComplete;
    [SerializeField] private float _destroyAfterCompleteDelay;
    //public Action OnTextComplete;
    private float _timeWhenCompleted;
    private LayerMask _playerLayer;
    private void Start()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }

    private IEnumerator BeginTalk()
    {
        foreach (char go in _words)
        {
            _text.text += go;
            yield return new WaitForSeconds(0.1f);
        }
        _timeWhenCompleted = Time.time;
        if (_destroyAfterComplete)
        {
            StartCoroutine(SelfDestroy());
        }
        yield return null;
    }
    private IEnumerator SelfDestroy()
    {
        while (true)
        {
            if (_timeWhenCompleted + _destroyAfterCompleteDelay < Time.time && Input.anyKey)
            {
                Destroy(_text.gameObject);
                Destroy(gameObject);
            }
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_text.text == "" && collision.gameObject.layer == _playerLayer)
        {
            StartCoroutine(BeginTalk());
        }
    }
}
