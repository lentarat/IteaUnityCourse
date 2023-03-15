using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    void Start()
    {
        _toggle.onValueChanged.AddListener(ValueChange);
    }
    private void ValueChange(bool state)
    {
        Debug.Log($"[{GetType().Name}] [{gameObject.name}] state: {state}");
    }
}
