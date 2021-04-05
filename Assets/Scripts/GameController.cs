using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Sources.Logic;
using Sources.Logic.EnemyLogic;
using Sources.Logic.GeneralLogic;
using Sources.Logic.PlayerLogic;
using Sources.Logic.TowerLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Globals _globals;
    [SerializeField] private BuildPanel _buildPanel;
    private Systems _systems;
    private Contexts _contexts;
    
    [Header("Static Views")]
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField] private GameObject _playerHealth;

    [Header("UI Elements")] 
    [SerializeField] private ProgressBarPro _playerHealthSlider;
    [SerializeField] private GameObject _loosePanel;
    [SerializeField] private TextMeshProUGUI _playerBalanceText;
    [SerializeField] private TextMeshProUGUI _killCountText;


    private void Start()
    {
        _contexts = Contexts.sharedInstance;
        _globals.IsPaused = false;
        
        SetUniqueEntities();

        _systems = CreateSystems();
        InitSystems();
    }

    public void Restart()
    {
        DestroyAll();
        _systems.DeactivateReactiveSystems();
        _systems.TearDown();
        _contexts.Reset();
        SetUniqueEntities();
        _loosePanel.SetActive(false);
        _globals.IsPaused = false;
        InitSystems();
    }

    private void SetUniqueEntities()
    {
        _contexts.game.SetGlobals(_globals);
        _contexts.game.SetStaticViews(_enemySpawner, _playerHealth);
        _contexts.game.SetUIElements(
            _playerHealthSlider, _loosePanel, 
            _buildPanel, _playerBalanceText, 
            _killCountText);
    }
    private void DestroyAll()
    {
        var entities = _contexts.game.GetEntities();
        foreach (var entity in entities)
        {
            if (entity.hasBuilding)
            {
                entity.building.BuildingBase.SetActive(true);
                entity.building.BuildingBase.GetComponent<Collider>().enabled = true;
            }
            if(entity.hasView && 
               !entity.hasEnemySpawner &&
               !entity.isPlayer) Destroy(entity.view.View);
        }
    }

    public void Exit() => Application.Quit();

    private void InitSystems()
    {
        _systems.ActivateReactiveSystems();
        _systems.Initialize();
    }
    private void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems()
    {
        return new Feature("Systems")
                .Add(new ViewPositionSystem(_contexts))
                .Add(new ViewRotationSystem(_contexts))
                .Add(new MoveSystem(_contexts))
                .Add(new LookAtMovementSystem(_contexts))

                .Add(new EnemySpawnerInitSystem(_contexts))
                .Add(new EnemySpawnSystem(_contexts))
                
                .Add(new PlayerInitSystem(_contexts))
                .Add(new PlayerHealthViewSystem(_contexts))
                .Add(new PlayerBalanceSystem(_contexts))
                .Add(new PlayerBalanceViewSystem(_contexts))
                .Add(new PlayerLoseSystem(_contexts))

                .Add(new BuildSystem(_contexts))
                .Add(new DemolishSystem(_contexts))

                .Add(new TowerFindTargetSystem(_contexts)) 
                .Add(new LookAtTargetSystem(_contexts))
                
                .Add(new ArcherShootSystem(_contexts))
                
                .Add(new DamageSystem(_contexts))
                .Add(new EnemyDieSystem(_contexts))
                
                .Add(new ShowBuildPanelSystem(_contexts))
            
                .Add(new TimerTickSystem(_contexts))
                .Add(new DestroySystem(_contexts))
            ;
    }
}
