using System;
using UnityEngine;
using StatePattern;
using UnityEditor.Experimental.GraphView;

public class MotorcycleEnemyModel : ModelBase, IEnemyModel
{
	public Vector2 Goal { get; set; }
	public Vector2 Position { get; set; }
	public float Speed { get; set; }
	public StateMachine Machine { get; set; }
	public EnemyWalkingState _walkingState;
	public EnemyAttackState _attackState;

	public bool IsColliding = false;


	public event EventHandler<EnemyMovedEventArgs> OnMove;
	public event EventHandler<EnemyMovedEventArgs> OnDelete;
	public MotorcycleEnemyModel(Vector2 goal, Vector2 currentposition)
	{
		Goal = goal;
		Position = currentposition;
		_walkingState = new EnemyWalkingState(this);
		_attackState = new EnemyAttackState(this);
		Machine = new StateMachine(_walkingState);

	}
	public void UpdatePosition(float deltaTime)
	{
		Machine.Update(deltaTime);
		Debug.Log(IsColliding);
	}
	public void OnMoved(Vector2 direction)
	{
		if (IsColliding)
		{
			Machine.SwitchState(_attackState);
		}
		else
		{
			OnMove.Invoke(this, new EnemyMovedEventArgs(direction));
		}
	}
}

