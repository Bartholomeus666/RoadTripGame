using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SimpleTurretModel : ModelBase, ITurret
{
    public float _cooldownTime { get; set; } = 5;
    public float _damage { get; set; }
    public float Range { get; set; }
    public Vector2 Position { get; set; }
    public GameObject Target { get; set; }
    public bool _readyToFire { get; set; } = false;

    public float BulletSpeed = 2f;

    public LayerMask TargetLayers;

    public event EventHandler<ShotFiredEventArgs> BulletFired;
    public SimpleTurretModel(Vector2 postion) 
    { 
        Position = postion;
    }

    public void Shoot()
    {
        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(Position, Range, TargetLayers);
        float targetDis = 10000000f;

        foreach(Collider2D target in targetInViewRadius)
        {
            if (Vector2.Distance(target.transform.position, Position) < targetDis)
            {
                Target = target.gameObject;
            }
        }
        if (Target != null)
        {
            BulletFired?.Invoke(this, new ShotFiredEventArgs(Target.gameObject.transform.position, BulletSpeed, this.Position)); 
            Target = null;
            _cooldownTime = 5f;
        }
    }

    public void Update(float deltaTime)
    {
        if (_cooldownTime > 0)
        { 
            _cooldownTime -= deltaTime;
        }
        else if(Target == null)
        {
            Shoot();
        }
    }
}
