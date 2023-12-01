using UnityEngine;

public class SetPanelManager : MonoBehaviour
{
    [SerializeField]
    private Panel[] _panels;

    private Panel _currentPanel;
    private Panel _oldPanel;

    /// <summary>
    /// �p�l����؂�ւ���֐�
    /// ���ݕ\������Ă���p�l�����\���ɂ���
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
    /// �p�l�����Z�b�g����֐�
    /// ���ݕ\������Ă���p�l�������̂܂܂ɂ��āA
    /// �w�肵���p�l����\������
    /// </summary>
    /// <param name="id"></param>
    public void SetPanel(int id)
    {
        _oldPanel = _currentPanel;
        _currentPanel = GetPanelById(id);
        _currentPanel?.gameObject.SetActive(true);
    }

    /// <summary>
    /// �w�肵���p�l�����\���ɂ���֐�
    /// </summary>
    /// <param name="id"></param>
    public void DisablePanel(int id)
    {
        GetPanelById(id).gameObject.SetActive(false);
    }

    /// <summary>
    /// �p�l����ID�Ō�������
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
