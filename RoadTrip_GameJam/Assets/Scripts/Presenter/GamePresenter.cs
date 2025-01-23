using System;
using System.ComponentModel;
using UnityEngine;

public class GamePresenter : PresenterBase<GameModel>
{
    [SerializeField] private GameObject _simpleTurretPrefab;




    private void Awake()
    {
        Model = new GameModel();
        Model.SpawnSimpleTurretModel += SpawnSimpleTurretPresenter;
    }

    private void SpawnSimpleTurretPresenter(object sender, SpawnModelEventArgs<SimpleTurretModel> e)
    {
        GameObject newSimpleTurret = Instantiate(_simpleTurretPrefab, e.Model.Position, Quaternion.identity);
        newSimpleTurret.GetComponent<SimpleTurretPresenter>().Model = e.Model;
    }

    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {

    }
}
