using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;
    private List<TMP_Dropdown.OptionData> _optionslist;
    void Start()
    {
        _dropdown.onValueChanged.AddListener(ValueChange);
        _optionslist = _dropdown.options;
    }
    private void ValueChange(int button)
    {
        Debug.Log($"[{GetType().Name}] [{gameObject.name}] panel: {_optionslist[button].text}");
    }
}
