using Entitas;
using UnityEngine;

[Game]
public class EnemySpawnerComponent : IComponent
{
    public float SpawnDelay;
    public Transform SpawnPoint;
    public GameObject EnemyPrefab;
}