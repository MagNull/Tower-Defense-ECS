using Entitas;
using UnityEngine;

[Game]
public class BuildCommandComponent : IComponent
{
    public BuildingType BuildingType;
    public Transform BuildPlace;
}