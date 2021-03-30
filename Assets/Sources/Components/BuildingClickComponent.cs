using Entitas;
using UnityEngine;

[Game]
public class BuildingClickComponent : IComponent
{
    public Transform BuildingPlace;
    public Vector3 CursorPosition;
    public bool IsBuilding;
}