namespace StatePattern
{
	public interface IState
	{
		void OnEnter(); // Only gets called once
		void Update(float deltatime); // Gets called every frame
		void OnExit(); // Only gets called once
	}
}
