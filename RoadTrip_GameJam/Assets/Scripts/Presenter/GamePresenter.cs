using System.ComponentModel;
using UnityEngine;

public class GamePresenter : PresenterBase<GameModel>
{
    public GameModel Model;

    

    private void Start()
    {
        Model = new GameModel();
    }





    protected override void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {

    }
}
