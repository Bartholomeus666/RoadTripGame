using UnityEngine;

public class EnemyMovedEventArgs
{
	public Vector2 _direction { get; set; }
	public EnemyMovedEventArgs(Vector2 direction)
	{
		_direction = direction;
	}
}

