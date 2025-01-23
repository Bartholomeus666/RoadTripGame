using UnityEngine;

public class SimpleTurretModel : ModelBase, ITurret
{
    public float _cooldownTime { get; set; }
    public float _damage { get; set; }
    public float _range { get; set; }
    public Vector2 Position { get; set; }

    public SimpleTurretModel(Vector2 postion) 
    { 
        Position = postion;
    }


}
