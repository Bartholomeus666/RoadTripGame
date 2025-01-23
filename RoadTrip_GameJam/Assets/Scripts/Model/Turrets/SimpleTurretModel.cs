using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SimpleTurretModel : ModelBase, ITurret
{
    public float _cooldownTime { get; set; }
    public float _damage { get; set; }
    public float Range { get; set; }
    public Vector2 Position { get; set; }
    public GameObject Target { get; set; }
    public bool _readyToFire { get; set; } = false;

    [SerializeField] LayerMask _targetLayers;

    public event EventHandler BulletFired;
    public SimpleTurretModel(Vector2 postion) 
    { 
        Position = postion;
    }

    public void Shoot()
    {
        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(Position, _range, _targetLayers);
        float targetDis = 10000000f;

        foreach(Collider2D target in targetInViewRadius)
        {
            if (Vector2.Distance(target.transform.position, Position) < targetDis)
            {
                Target = target.gameObject;
            }
        }
        BulletFired?.Invoke(this, new EventArgs());
        Target = null;
    }

    public void Update(float deltaTime)
    {
        if (_cooldownTime > 0)
        { 
            _cooldownTime -= deltaTime;
        }
    }
}
