using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;

public class GachaView : MonoBehaviour
{
    public System.Func<UniTask<string>> OnClickGachaButtonDelegate;

    [SerializeField]
    private Button _gachaButton;

    [SerializeField]
    private TMP_Text _text;

    private void Start()
    {
        _gachaButton.onClick.AddListener(OnClickGachaButton);
    }

    private async void OnClickGachaButton()
    {
        var result = await OnClickGachaButtonDelegate.Invoke();

        _text.text = result;
    }
}
