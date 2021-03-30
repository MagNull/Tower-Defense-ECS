using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Sources.Logic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Globals _globals;
    [SerializeField] private Transform _enemySpawnPoint;
    [SerializeField] private BuildPanel _buildPanel;
    private Systems _systems;
    private Contexts _contexts;

    private void Start()
    {
        _contexts = Contexts.sharedInstance;
        _globals.EnemySpawnPoint = _enemySpawnPoint;
        _contexts.game.SetGlobals(_globals);

        _systems = CreateSystems();
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems()
    {
        return new Feature("Systems")
                .Add(new TimerTickSystem(_contexts))
                
                .Add(new ViewPositionSystem(_contexts))
                .Add(new ViewRotationSystem(_contexts))
                .Add(new MoveSystem(_contexts))
                .Add(new LookAtMovementSystem(_contexts))

                .Add(new EnemyInitSystem(_contexts))
                .Add(new EnemySpawnSystem(_contexts))

                .Add(new BuildSystem(_contexts))
                .Add(new DemolishSystem(_contexts))

                .Add(new ShowBuildPanelSystem(_contexts, _buildPanel))
                .Add(new DestroySystem(_contexts))
            ;
    }
}
