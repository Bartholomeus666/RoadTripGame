using UnityEngine;

public class SimpleTurretModel : ModelBase, ITurret
{
    public float _cooldownTime { get; set; }
    public float _damage { get; set; }
    public float _range { get; set; }


}
