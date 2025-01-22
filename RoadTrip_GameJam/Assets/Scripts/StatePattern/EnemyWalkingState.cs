using System.Numerics;
using System;
using StatePattern;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

namespace StatePattern
{
	public class EnemyWalkingState : IState
	{
		IEnemyModel _model;
		public EnemyWalkingState(IEnemyModel model)
		{
			_model = model;
		}
		public void OnEnter()
		{

		}

		public void OnExit()
		{
		}

		public void Update(float deltatime)
		{
			// Move towards the goal
			Vector2 direction = _model.Goal - _model.Position;
			if (Vector2.Distance(_model.Goal, _model.Position) < 0.1f)
			{
				direction = Vector2.Zero;
				_model.Machine.SwitchState(new EnemyIdleState(_model));
			}
			direction = Vector2.Normalize(direction);
			direction *= _model.Speed;
			_model.OnMoved(direction);
		}
	}
}
