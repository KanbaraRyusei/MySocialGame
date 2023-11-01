using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaPresenter : MonoBehaviour
{
    [SerializeField]
    private GachaView _view;

    private GachaModel _model;

    private void Awake()
    {
        _model = new GachaModel();
        _view.OnClickGachaButtonDelegate += _model.DrawGachaAndGetResultName;
    }
}
