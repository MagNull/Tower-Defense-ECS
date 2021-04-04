using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class StaticViewsComponent : IComponent
{
    public GameObject EnemySpawner;
    public GameObject PlayerHealth;
}