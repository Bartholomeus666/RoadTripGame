using System.ComponentModel;
using UnityEngine;

public class SneakyPlayerPresenter : PresenterBase<SneakyPlayerModel>
{


    private void Awake()
    {
        Model = new SneakyPlayerModel();
    }

    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {

    }
}
