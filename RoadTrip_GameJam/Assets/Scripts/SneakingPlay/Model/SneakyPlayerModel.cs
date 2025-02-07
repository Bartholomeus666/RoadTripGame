using System;
using UnityEngine;

public class SneakyPlayerModel: ModelBase
{
    public event EventHandler<SneakyMovementEventArgs> GoToNextPointOnLine;
    private Vector3[] _points;

    public Vector3[] Points
    {
        get { return _points; }
        set
        {
            if (value != _points)
            {
                _points = value;
                OnPropertyChanged(); // Notify subscribers about the change
            }
        }
    }

    private int _index = 0;

    public int Index { 
        get { return _index; } 
        set 
        {
            if (_index != value)
            {
                _index = value;
                OnPropertyChanged();
            }
        }
    }

    public void GetLine(LineRenderer lineRenderer)
    {
        Points = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(_points);
    }

    public void NextPoint()
    {
        _index++;
    }
}
