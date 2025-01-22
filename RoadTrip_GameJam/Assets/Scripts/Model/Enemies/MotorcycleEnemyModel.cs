using System.Numerics;
using System;
using StatePattern;
using UnityEditor.Experimental.GraphView;

public class MotorcycleEnemyModel : ModelBase, IEnemyModel
{
	public Vector2 Goal { get; set; }
	public Vector2 Position { get; set; }
	public float Speed { get; set; }
	public StateMachine Machine { get; set; }
	public EnemyWalkingState _walkingState;


	public event EventHandler<EnemyMovedEventArgs> OnMove;
	public MotorcycleEnemyModel(Vector2 goal, Vector2 currentposition, float speed)
	{
		Goal = goal;
		Position = currentposition;
		Speed = speed;
		_walkingState = new EnemyWalkingState(this);

	}
	public void UpdatePosition(float deltaTime)
	{
		Machine.Update(deltaTime);
	}
	public void OnMoved(Vector2 direction)
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

