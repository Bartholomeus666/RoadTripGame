using System;
using UnityEngine;

public class SneakyPlayerModel: ModelBase
{
    public event EventHandler GoToNextPointOnLine;

    public void FollowLine(LineRenderer lineRenderer)
    {
        Debug.Log("Crazy");
    }
}
