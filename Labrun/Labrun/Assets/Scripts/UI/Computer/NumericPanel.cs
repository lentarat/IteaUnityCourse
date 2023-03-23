using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NumericPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private string _finalText;
    [SerializeField] private TextMeshProUGUI _welcomeText;
    public Action OnAccessGranted;
    private void Awake()
    {
        Button[] _buttons = GetComponentsInChildren<Button>();
        _buttons[0].onClick.AddListener(Enter1);
        _buttons[1].onClick.AddListener(Enter2);
        _buttons[2].onClick.AddListener(Enter3);
        _buttons[3].onClick.AddListener(Enter4);
        _buttons[4].onClick.AddListener(Enter5);
        _buttons[5].onClick.AddListener(Enter6);
        _buttons[6].onClick.AddListener(Enter7);
        _buttons[7].onClick.AddListener(Enter8);
        _buttons[8].onClick.AddListener(Enter9);
        _buttons[9].onClick.AddListener(Enter0);
    }

    private void Update()
    {
        if (Input.anyKey ^ Input.GetMouseButton(0) ^ Input.GetKey(KeyCode.E))
        {
            gameObject.SetActive(false);
        }
    }
    private void Check(int num)
    {
        if (_currentText.text.Length < 4)
        {
            _currentText.text += num;
        }
        else
        {
            _currentText.text = "";
            _currentText.text += num;   
        }
        if (_currentText.text == _finalText)
        {
            _welcomeText.enabled = true;
            OnAccessGranted();
        }
    }
    //як зробити краще?
    private void Enter1()
    {
        Check(1);
        
    }
    private void Enter2()
    {
        Check(2);
    }
    private void Enter3()
    {
        Check(3);
    }
    private void Enter4()
    {
        Check(4);
    }
    private void Enter5()
    {
        Check(5);
    }
    private void Enter6()
    {
        Check(6);
    }
    private void Enter7()
    {
        Check(7);
    }
    private void Enter8()
    {
        Check(8);
    }
    private void Enter9()
    {
        Check(9);
    }
    private void Enter0()
    {
        Check(0);
    }
}
