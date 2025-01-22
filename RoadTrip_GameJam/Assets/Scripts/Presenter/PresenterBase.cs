using System.ComponentModel;
using UnityEngine;

public abstract class PresenterBase<TModel> : MonoBehaviour where TModel : ModelBase
{
    private TModel _model;

    public TModel Model
    {
        get { return _model; }
        set
        {
            _model = value;
            _model.PropertyChanged += HandlePropertyChanged;
        }
    }
    protected abstract void HandlePropertyChanged(object sender, PropertyChangedEventArgs e);
}
