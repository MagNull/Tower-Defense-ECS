using Entitas;
using UnityEngine;

[Game]
public class BuildCommandComponent : IComponent
{
    public TowerType TowerType;
    public Transform BuildPlace;
}