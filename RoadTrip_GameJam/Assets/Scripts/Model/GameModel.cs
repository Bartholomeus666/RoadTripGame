using System;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : ModelBase
{

    public List<EnemyModelBase> EnemyModels;

    public event EventHandler<SpawnModelEventArgs<SimpleTurretModel>> SpawnSimpleTurretModel;


    public GameModel() 
    {
        EnemyModels = new List<EnemyModelBase>();
    }





    public void SpawnSimpleTurret(Vector2 postition)
    {
        SimpleTurretModel newSimpleTurret = new SimpleTurretModel(postition);
        SpawnSimpleTurretModel?.Invoke(this, new SpawnModelEventArgs<SimpleTurretModel>(newSimpleTurret));
    }
}
