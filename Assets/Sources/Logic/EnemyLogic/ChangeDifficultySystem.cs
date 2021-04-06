using Entitas;
using UnityEngine;

public class ChangeDifficultySystem : IExecuteSystem  
{
	private Contexts _contexts;
	private IGroup<GameEntity> _group;

    public ChangeDifficultySystem(Contexts contexts) 
    {
    	_contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.EnemySpawner);
    }

	public void Execute()
	{
		float newDelay = _contexts.game.globals.value.EnemySpawnDelay - _contexts.game.globals.value.EnemyDifficultyCoefficient *
			_contexts.game.globals.value.KillCount;
		foreach (var e in _group)
		{
			e.enemySpawner.SpawnDelay = Mathf.Clamp(newDelay, .2f, 100);
		}
	}
}