using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject
{
    [HideInInspector]
    public Transform EnemySpawnPoint;
    public GameObject EnemyPrefab;

    [Header("Towers Prefab")]
    public GameObject ArcherTower;
    public GameObject ArcherTowerConstruct;
    public GameObject CanonTower;

    [Header("Archer Tower Configs")] 
    public float ArcherShootDistance;
    public float ArcherShootDelay;
    public GameObject ArrowPrefab;
    public float ArrowSpeed;
}