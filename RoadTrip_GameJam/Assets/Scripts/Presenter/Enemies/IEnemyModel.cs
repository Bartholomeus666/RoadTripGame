using System;
using UnityEngine;
using StatePattern;
public interface IEnemyModel
{
	public Vector2 Goal {get; set; }
	public Vector2 Position { get; set; }
	public float Speed { get; set; }
	public StateMachine Machine { get; set; }
	public void OnMoved(Vector2 direction);

	public event EventHandler<EnemyMovedEventArgs> OnDelete;
}
