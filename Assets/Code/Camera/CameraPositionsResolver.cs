using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionsResolver : ICameraPositionsResolver
{
    private readonly IDictionary<Type, Vector3> _positions;

    public CameraPositionsResolver()
    {
        _positions = new Dictionary<Type, Vector3>();
    }

    public void RegisterPosition(Type type, Vector3 position)
    {
        _positions.Add(type, position);
    }

    //public Vector3 GetLobbyPosition()
    //{
    //    return _positions[typeof(LobbyController)];
    //}

    //public Vector3 GetMapPosition()
    //{
    //    return _positions[typeof(MapController)];
    //}
}
