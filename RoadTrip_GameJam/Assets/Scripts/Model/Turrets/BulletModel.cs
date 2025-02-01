using UnityEngine;

public class BulletModel : ModelBase, IBullet
{
    public Vector2 Target { get; set; }
    public float Speed { get; set; }
    public Vector2 StartPosition;

    public BulletModel(Vector2 target, float speed, Vector2 startPosition)
    {
        Target = target;
        Speed = speed;
        StartPosition = startPosition;
    }

    public Quaternion GetBulletRotation()
    {
        Quaternion newAngle = new Quaternion(0, 0, Vector3.Angle(Target, StartPosition),0);

        return newAngle;
    }
}
