using System.Numerics;
using System;
using UnityEditor.Experimental.GraphView;

public class MotorcycleEnemyModel : ModelBase
{
	Vector2 _goal;
	Vector2 _currentPosition;
	private float _speed;

	public event EventHandler<EnemyMovedEventArgs> OnMove;
	public MotorcycleEnemyModel(Vector2 goal, Vector2 currentposition, float speed)
	{
		_goal = goal;
		_currentPosition = currentposition;
		_speed = speed;
	}
	public void UpdatePosition()
	{
		// Move towards the goal
		Vector2 direction = _goal - _currentPosition;
		if (_currentPosition == _goal)
		{
			direction = Vector2.Zero;
		}
		direction = Vector2.Normalize(direction);
		direction *= _speed;
		OnMoved(direction);
	}

	private void OnMoved(Vector2 direction)
	{
		OnMove.Invoke(this, new EnemyMovedEventArgs(direction));
	}
}
public class EnemyMovedEventArgs
{
	public Vector2 _direction { get; set; }
	public EnemyMovedEventArgs(Vector2 direction)
	{
		_direction = direction;
	}
}

