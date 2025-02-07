using System.ComponentModel;
using UnityEngine;

public class SneakyPlayerPresenter : PresenterBase<SneakyPlayerModel>
{
    [SerializeField] private float _speed;
    private bool _canMove = false;
    private Vector3 _targetPosition;
    private int _targetIndex = 1;

    private void Awake()
    {
        Model = new SneakyPlayerModel();
        Model.PropertyChanged += HandlePropertyChanged;
    }

    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        _canMove = true;
        Debug.Log("Can move? " + _canMove);

        _targetPosition = Model.Points[_targetIndex];
        _targetIndex++;

    }

    private void Update()
    {
        if (_canMove)
        {
            Debug.Log(Vector3.Distance(Model.Points[_targetIndex - 1], _targetPosition));
            transform.position = Vector3.MoveTowards(Model.Points[_targetIndex - 1], _targetPosition, _speed + Time.deltaTime);
        }
        if (Vector3.Distance(this.transform.position, _targetPosition) < 0.001)
        {
            Model.NextPoint();
        }
    }
}
