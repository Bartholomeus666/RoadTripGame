using System.ComponentModel;
using UnityEngine;

public class SimpleTurretPresenter : PresenterBase<SimpleTurretModel>
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _layerMask;

    private void Start()
    {
        Model.Range = _range;
        Model.TargetLayers = _layerMask;
    }
    private void Update()
    {
        Model.Update(Time.deltaTime);

    }
    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        
    }
}
