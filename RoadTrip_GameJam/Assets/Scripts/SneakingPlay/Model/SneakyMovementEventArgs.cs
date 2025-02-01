using UnityEngine;

public class SneakyMovementEventArgs
{
    public Vector2 TargetPosition;

    public SneakyMovementEventArgs(Vector2 targetPosition)
    {
        TargetPosition = targetPosition;
    }
}
