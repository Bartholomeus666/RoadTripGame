using System;

public class SpawnModelEventArgs<TModel> where TModel : ModelBase
{
    public TModel Model { get; set; }

    public SpawnModelEventArgs(TModel model)
    {
        Model = model;
    }
}
