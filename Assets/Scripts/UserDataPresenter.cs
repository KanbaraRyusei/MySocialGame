using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;

public class UserDataPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayfabLogin _pl;

    [SerializeField]
    private UserDataView _view;

    private UserDataModel _model;

    private async void Start()
    {
        _model = new UserDataModel();

        await UniTask.WaitUntil(() => _pl.WasLogin);

        await _model.Init();

        //_view.ObserveEveryValueChanged(x => x.)
            //.Subscribe(x => );
    }
}
