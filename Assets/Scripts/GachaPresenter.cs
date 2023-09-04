using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaPresenter : MonoBehaviour
{
    [SerializeField]
    private GachaView _view;

    [SerializeField]
    private GachaModel _model;

    private void Start()
    {
        _view.OnClickGachaButtonDelegate += _model.DrawGachaAndGetResultName;
    }
}