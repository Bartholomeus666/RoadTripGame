using UnityEngine;

public interface ITurret
{
    float _cooldownTime { get; set; }
    float _damage { get; set; }
    float Range { get; set; }
    bool _readyToFire { get; set; }
    public GameObject Target { get; set; }

    public void Shoot();
    public void Update(float deltaTime);
}
