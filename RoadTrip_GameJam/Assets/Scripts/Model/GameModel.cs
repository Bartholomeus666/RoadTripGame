using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameModel : ModelBase
{
    public List<IEnemyModel> EnemyModels;

    public event EventHandler<SpawnModelEventArgs<SimpleTurretModel>> SpawnSimpleTurretModel;
    public event EventHandler<SpawnModelEventArgs<MotorcycleEnemyModel>> SpawnMotorCycleEnemyModel;

	public GameObject _wagon;

	public int IntervalMotorcycles;

	float _time;

	
	public GameModel(int intervalMotorcycles) 
    {
		IntervalMotorcycles = intervalMotorcycles;
		EnemyModels = new List<IEnemyModel>();
	}

	public void Update(float deltaTime)
	{
		_time += deltaTime;

		if (_time > IntervalMotorcycles)
		{
			_time = 0;
			SpawnMotorCycle(new Vector2(-12, UnityEngine.Random.Range(-5, 5)));
		}
	}
	public void SpawnMotorCycle(Vector2 postition)
	{
		MotorcycleEnemyModel newEnemy = new MotorcycleEnemyModel(_wagon.transform.position, postition);
		EnemyModels.Add(newEnemy);
		SpawnMotorCycleEnemyModel?.Invoke(this, new SpawnModelEventArgs<MotorcycleEnemyModel>(newEnemy));
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
