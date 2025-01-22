using System;
using System.Collections.Generic;
using UnityEngine;

public class GameModel: ModelBase
{
    //SPAWNEVENTS
    public event EventHandler<SpawnModelEventArgs<SimpleTurretModel>> SpawnSimpleTurretModel;


    public List<EnemyModelBase> EnemyModels;


    public void SpawnTurret<T>(T turretModel ) where T: TurretModelBase
    {

    }
}
