using System.ComponentModel;
using UnityEngine;

public class SneakyPlayerPresenter : PresenterBase<SneakyPlayerModel>
{
    [SerializeField] private float _speed;
    private bool _canMove = false;
    private Vector3 _targetPosition;
    private int _targetIndex = 0;

    private void Awake()
    {
        Model = new SneakyPlayerModel();
        Model.PropertyChanged += HandlePropertyChanged;
    }

    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        _targetPosition = Model.Points[_targetIndex];
        _targetIndex++;
        _canMove = true;

        //if (_targetPosition != new Vector3(0, 0, 0))
        //{
        //    _canMove = true;
        //}
    }

    private void Update()
    {
        if (_canMove)
        {
            Debug.Log($"Position: {_targetPosition} \n  Distance: {Vector3.Distance(transform.position, _targetPosition)}");
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed + Time.deltaTime);
        }
        if (Vector3.Distance(this.transform.position, _targetPosition) < 0.001 && _canMove)
        {
            Model.NextPoint();
        }
    }
}
