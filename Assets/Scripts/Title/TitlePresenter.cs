using UnityEngine;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField]
    private TitleView _view;

    private TitleModel _model;

    private void Start()
    {
        _view.OnClickTitleButtonDelegate += _model.TitleInit;
    }
}
