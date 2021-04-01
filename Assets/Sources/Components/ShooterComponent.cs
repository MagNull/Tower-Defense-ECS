using Entitas;
using UnityEngine;

[Game]
public class ShooterComponent : IComponent
{
    public GameObject View;
    public Transform ShootPoint;
    public TowerType Type;
    public Transform Target;
    public float ShootDistance;
    public float ShootSpeed;
}