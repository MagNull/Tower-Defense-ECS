using Entitas;
using UnityEngine;

[Game]
public class BuildingComponent : IComponent
{
    public BuildingType BuildingType;
    public GameObject BuildingBase;
    public GameObject Upgrade;
}