using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private Button _button;
    void Start()
    {
        _button.onClick.AddListener(Click);
    }
    private void Click()
    {
        Debug.Log($"[{GetType().Name}] [{gameObject.name}] clicked");
    }
}
