using System;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : ModelBase
{

    public List<IEnemyModel> EnemyModels;

    public event EventHandler<SpawnModelEventArgs<SimpleTurretModel>> SpawnSimpleTurretModel;
    public event EventHandler<SpawnModelEventArgs<MotorcycleEnemyModel>> SpawnEnemyModel;

	public GameObject _wagon;

	public GameModel() 
    {
        EnemyModels = new List<IEnemyModel>();
	}
	public void Start()
	{
		SpawnEnemy(new Vector2(-4, -4));
	}


	public void SpawnEnemy(Vector2 postition)
	{
		MotorcycleEnemyModel newEnemy = new MotorcycleEnemyModel(_wagon.transform.position, postition);
		EnemyModels.Add(newEnemy);
		SpawnEnemyModel?.Invoke(this, new SpawnModelEventArgs<MotorcycleEnemyModel>(newEnemy));
	}

	public void SpawnSimpleTurret(Vector2 postition)
    {
        SimpleTurretModel newSimpleTurret = new SimpleTurretModel(postition);
        SpawnSimpleTurretModel?.Invoke(this, new SpawnModelEventArgs<SimpleTurretModel>(newSimpleTurret));
        newSimpleTurret.BulletFired += SpawnBullet;
    }

    private void SpawnBullet(object sender, EventArgs e)
    {
        Debug.Log("Shoot Bullet");
    }
}
