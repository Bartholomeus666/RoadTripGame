namespace StatePattern
{
	public class StateMachine
	{
		public IState CurrentState;

		public StateMachine(IState initialState)
		{
			CurrentState = initialState;
			CurrentState.OnEnter();  // Enter initial state
		}

		public void Update(float deltatime)
		{
			CurrentState.Update(deltatime);  // Update the current state
		}

		public void SwitchState(IState newState)
		{
			CurrentState.OnExit();  // Exit the current state
			CurrentState = newState;  // Switch to the new state
			CurrentState.OnEnter();  // Enter the new state
		}
	}
}
