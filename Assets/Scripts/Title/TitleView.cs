using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using TMPro;

public class TitleView : MonoBehaviour
{
    public System.Func<UniTask<string>> OnClickTitleButtonDelegate;

    [SerializeField]
    private Button _titleButton;

    [SerializeField]
    private TMP_Text _text;

    private void Start()
    {
        _titleButton.onClick.AddListener(OnClickTitleButton);
    }

    private async void OnClickTitleButton()
    {
        var result = await OnClickTitleButtonDelegate.Invoke();

        _text.text = result;
    }
}
