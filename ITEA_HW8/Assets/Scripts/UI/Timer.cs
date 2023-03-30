using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeLeft;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Button _button;
    public Action OnTimerEnd;
    private void Awake()
    {
        _button.OnButtonClicked += DisplayTime;
        /////////////
        ///
        //DisplayTime();
        /// 
        /////////////
    }
    private void DisplayTime()
    {
        StartCoroutine(DisplayTimeLeft());
    }
    private IEnumerator DisplayTimeLeft()
    {
        while (true)
        {
            if (_timeLeft > 0f)
            {
                _timeLeft -= Time.deltaTime;
                _timerText.text = _timeLeft.ToString();
                yield return null;
            }
            else
            {
                _timeLeft = 0f;
                _timerText.text = _timeLeft.ToString();
                OnTimerEnd();
                break;
            }
        }
        yield return null;
    }
}
