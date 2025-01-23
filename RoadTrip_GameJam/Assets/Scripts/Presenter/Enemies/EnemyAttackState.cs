using StatePattern;

public class EnemyAttackState : IState
{
	IEnemyModel _model;
	public EnemyAttackState(IEnemyModel model)
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
		// Attack the player
	}
}
