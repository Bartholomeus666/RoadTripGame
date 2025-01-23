using UnityEngine;

public class ShotFiredEventArgs
{
    public Vector2 Target;
    public float Speed;
    public Vector2 StartPosition;

    public ShotFiredEventArgs(Vector2 target, float speed, Vector2 startPosition)
    {
        Target = target;
        Speed = speed;
        StartPosition = startPosition;
    }
}
