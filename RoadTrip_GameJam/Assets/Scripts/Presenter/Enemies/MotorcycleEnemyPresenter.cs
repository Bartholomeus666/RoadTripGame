using System.ComponentModel;
using UnityEngine;
using System;


public class MotorcycleEnemyPresenter : PresenterBase<MotorcycleEnemyModel>
{
	[SerializeField]float _speed;

	bool _isColliding = false;
	protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		throw new System.NotImplementedException();
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		Model.Speed = _speed;
		Model.OnMove += MoveCharacter;
	}

    // Update is called once per frame
    void Update()
    {
        Model.UpdatePosition(Time.deltaTime);
		Model.Position = new Vector2(transform.position.x, transform.position.y);
		Model.IsColliding = _isColliding;
	}
	public void MoveCharacter(object sender, EnemyMovedEventArgs e)
	{
		transform.position += new Vector3(e._direction.x, e._direction.y, 0) * Time.deltaTime;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			_isColliding = true;
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			_isColliding = false;
		}
	}
}