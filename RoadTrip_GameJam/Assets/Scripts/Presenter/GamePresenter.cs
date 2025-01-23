using System;
using System.ComponentModel;
using UnityEngine;

public class GamePresenter : PresenterBase<GameModel>
{
    [SerializeField] private GameObject _simpleTurretPrefab;

    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private GameObject _playerPrefab;

    [SerializeField] private int IntervalMotorcycles;


	private void Awake()
    {
        Model = new GameModel(IntervalMotorcycles);
        Model.SpawnSimpleTurretModel += SpawnSimpleTurretPresenter;
		Model.SpawnMotorCycleEnemyModel += SpawnMotorcycleEnemyPresenter;

        //Delete
        Model._wagon = _playerPrefab;
	}
	private void Update()
	{
		Model.Update(Time.deltaTime);
	}

	private void SpawnSimpleTurretPresenter(object sender, SpawnModelEventArgs<SimpleTurretModel> e)
    {
        GameObject newSimpleTurret = Instantiate(_simpleTurretPrefab, e.Model.Position, Quaternion.identity);
        newSimpleTurret.GetComponent<SimpleTurretPresenter>().Model = e.Model;
    }

    private void SpawnMotorcycleEnemyPresenter(object sender, SpawnModelEventArgs<MotorcycleEnemyModel> e)
    {
        GameObject newEnemy = Instantiate(_enemyPrefab, e.Model.Position, Quaternion.identity);
        newEnemy.GetComponent<MotorcycleEnemyPresenter>().Model = e.Model;
    }
	private void SpawnWagonPresenter(object sender, SpawnModelEventArgs<MotorcycleEnemyModel> e)
	{
		GameObject newEnemy = Instantiate(_enemyPrefab, e.Model.Position, Quaternion.identity);
		newEnemy.GetComponent<MotorcycleEnemyPresenter>().Model = e.Model;
	}
	protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {

    }
}
