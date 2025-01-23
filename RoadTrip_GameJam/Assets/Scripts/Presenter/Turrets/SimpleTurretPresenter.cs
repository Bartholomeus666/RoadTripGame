using System.ComponentModel;
using UnityEngine;

public class SimpleTurretPresenter : PresenterBase<SimpleTurretModel>
{
    [SerializeField] private float _range;

    private void Start()
    {
        Model.Range = _range;
    }
    private void Update()
    {
        Model.Update(Time.deltaTime);

    }
    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        
    }
}
