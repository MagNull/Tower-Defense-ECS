using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu]
public class Globals : ScriptableObject
{
    public bool IsPaused;
    public int KillCount;
    
    [HideInInspector]
    public GameObject EnemyPrefab;

    [Header("Enemy Configs")] 
    public float EnemySpawnDelay;
    public float EnemyMovementSpeed;
    public int EnemyHealth;

    [Header("Player Configs")] 
    public int PlayerHealth;
    public int PlayerBalance;

    [Header("Towers Prefab")]
    public GameObject ArcherTower;
    public GameObject ArcherTowerConstruct;
    public GameObject CanonTower;

    [Header("Archer Tower Configs")] 
    public int ArcherTowerCost;
    public float ArcherShootDistance;
    public float ArcherShootDelay;
    public GameObject ArrowPrefab;
    public float ArrowSpeed;
}