using System;
using UnityEngine;

public interface ICameraPositionsResolver
{
    void RegisterPosition(Type type, Vector3 position);
    //Vector3 GetLobbyPosition();
    //Vector3 GetMapPosition();
}
