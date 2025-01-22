using System;
using System.ComponentModel;
using UnityEngine;

public class GamePresenter : PresenterBase<GameModel>
{
    [SerializeField] private GameObject _simpleTurretPrefab;




    private void Start()
    {
        Model = new GameModel();
        Model.SpawnSimpleTurretModel += SpawnSimpleTurretPresenter;
    }

    private void SpawnSimpleTurretPresenter(object sender, SpawnModelEventArgs<SimpleTurretModel> e)
    {
        GameObject newSimpleTurret = Instantiate(_simpleTurretPrefab, Vector3.zero, Quaternion.identity);
    }

    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {

    }
}
