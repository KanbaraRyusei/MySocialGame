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
    private UserDataModel _model;

    [SerializeField]
    private UserDataView _view;

    private async void Start()
    {
        await UniTask.WaitUntil(() => _pl.WasLogin);

        await _model.Init();

        Debug.Log(111);

        //_view.ObserveEveryValueChanged(x => x.)
            //.Subscribe(x => );
    }
}
