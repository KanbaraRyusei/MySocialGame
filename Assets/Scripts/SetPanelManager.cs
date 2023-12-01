using UnityEngine;

public class SetPanelManager : MonoBehaviour
{
    [SerializeField]
    private Panel[] _panels;

    private Panel _currentPanel;
    private Panel _oldPanel;

    /// <summary>
    /// パネルを切り替える関数
    /// 現在表示されているパネルを非表示にする
    /// </summary>
    /// <param name="id"></param>
    public void ChangePanel(int id)
    {
        _oldPanel = _currentPanel;
        _oldPanel.gameObject.SetActive(false);
        _currentPanel = GetPanelById(id);
        _currentPanel?.gameObject.SetActive(true);
    }

    /// <summary>
    /// パネルをセットする関数
    /// 現在表示されているパネルをそのままにして、
    /// 指定したパネルを表示する
    /// </summary>
    /// <param name="id"></param>
    public void SetPanel(int id)
    {
        _oldPanel = _currentPanel;
        _currentPanel = GetPanelById(id);
        _currentPanel?.gameObject.SetActive(true);
    }

    /// <summary>
    /// 指定したパネルを非表示にする関数
    /// </summary>
    /// <param name="id"></param>
    public void DisablePanel(int id)
    {
        GetPanelById(id).gameObject.SetActive(false);
    }

    /// <summary>
    /// パネルをIDで検索する
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private Panel GetPanelById(int id)
    {
        foreach(var p in _panels)
        {
            if(p.ID == id)
            {
                return p;
            }
        }

        Debug.LogError("ID : " + id + "Panel is Not Found");
        return null;
    }
}
