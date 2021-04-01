using Entitas;
using UnityEngine;

[Game]
public class BuildingComponent : IComponent
{
    public TowerType TowerType;
    public GameObject BuildingBase;
    public GameObject Upgrade;
}