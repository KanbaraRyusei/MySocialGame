using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserDataView : MonoBehaviour
{
    public string InputField => _inputField.name;

    [SerializeField]
    private Button _button;

    [SerializeField]
    private TMP_InputField _inputField;

    public void Init()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {

    }
}
