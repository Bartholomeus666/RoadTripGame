using System.ComponentModel;
using UnityEngine;
using System.Numerics;
using System;


public class MotorcycleEnemyPresenter : PresenterBase<MotorcycleEnemyModel>
{
	[SerializeField] float _speed;
	protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		throw new System.NotImplementedException();
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        Model = new MotorcycleEnemyModel(new System.Numerics.Vector2(3, 3), new System.Numerics.Vector2(transform.position.x, transform.position.y), _speed);
		Model.OnMove += MoveCharacter;
	}

    // Update is called once per frame
    void Update()
    {
        Model.UpdatePosition(Time.deltaTime);
		Model.Position = new System.Numerics.Vector2(transform.position.x, transform.position.y);
	}
	public void MoveCharacter(object sender, EnemyMovedEventArgs e)
	{
		transform.position += new UnityEngine.Vector3(e._direction.X, e._direction.Y, 0) * Time.deltaTime;
	}

}