using System;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : ModelBase
{

    public List<EnemyModelBase> EnemyModels;

    public event EventHandler<SpawnModelEventArgs<SimpleTurretModel>> SpawnSimpleTurretModel;








    public void SpawnSimpleTurret()
    {
        SimpleTurretModel newSimpleTurret = new SimpleTurretModel();
        SpawnSimpleTurretModel?.Invoke(this, new SpawnModelEventArgs<SimpleTurretModel>(newSimpleTurret));
    }
}
