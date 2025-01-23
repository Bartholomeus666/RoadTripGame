using System;
using System.ComponentModel;
using UnityEngine;

public class GamePresenter : PresenterBase<GameModel>
{
    [SerializeField] private GameObject _simpleTurretPrefab;

    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _bulletPrefab;


    private void Awake()
    {
        Model = new GameModel();
        Model.SpawnSimpleTurretModel += SpawnSimpleTurretPresenter;
		Model.SpawnEnemyModel += SpawnEnemyPresenter;
        Model.SpawnBulletModel += SpawnBulletPresenter;

        //Delete
        Model._wagon = _playerPrefab;

        Model.Start();

	}

    private void SpawnBulletPresenter(object sender, SpawnModelEventArgs<BulletModel> e)
    {
        GameObject newBullet = Instantiate(_bulletPrefab, e.Model.StartPosition, Quaternion.identity);
        newBullet.GetComponent<BulletPresenter>().Model = e.Model;
    }

    private void SpawnSimpleTurretPresenter(object sender, SpawnModelEventArgs<SimpleTurretModel> e)
    {
        GameObject newSimpleTurret = Instantiate(_simpleTurretPrefab, e.Model.Position, Quaternion.identity);
        newSimpleTurret.GetComponent<SimpleTurretPresenter>().Model = e.Model;
    }

    private void SpawnEnemyPresenter(object sender, SpawnModelEventArgs<MotorcycleEnemyModel> e)
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
