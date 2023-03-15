using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    void Start()
    {
        _slider.onValueChanged.AddListener(ValueChange);    
    }
    private void ValueChange(float value)
    {

        Debug.Log($"[{GetType().Name}] [{gameObject.name}] value: {value}");
    }
}
