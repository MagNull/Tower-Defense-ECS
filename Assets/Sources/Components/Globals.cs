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
    public float EnemyDifficultyCoefficient;

    [Header("Player Configs")] 
    public int PlayerHealth;
    public int PlayerBalance;

    [Header("Towers Prefab")]
    public GameObject ArcherTower;
    public GameObject ArcherTowerConstruct;
    public GameObject MageTower;
    public GameObject MageTowerConstruct;

    [Header("Archer Tower Configs")] 
    public int ArcherTowerCost;
    public float ArcherShootDistance;
    public float ArcherShootDelay;
    public GameObject ArrowPrefab;
    public float ArrowSpeed;
    public int ArrowDamage;

    [Header("Mage Tower Configs")] 
    public int MageTowerCost;
    public float MageTowerDistance;
    public float MageShootDelay;
    public GameObject MagicBlastPrefab;
    public int MagicBlastDamage;
}