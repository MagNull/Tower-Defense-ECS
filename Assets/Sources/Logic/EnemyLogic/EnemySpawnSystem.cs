using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic.EnemyLogic
{
	public class EnemySpawnSystem : ReactiveSystem<GameEntity> 
	{
		private Contexts _contexts;
    
		public EnemySpawnSystem (Contexts contexts) : base(contexts.game) 
		{
			_contexts = contexts;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.EnemySpawner);
		}
		
		protected override bool Filter(GameEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameEntity> entities) 
		{
			foreach (var e in entities)
			{
				var globals = _contexts.game.globals.value;
				StartTimer(e, globals);
				
			}
		}

		private void StartTimer(GameEntity e, Globals globals)
		{
			CreateEnemy(globals, e.enemySpawner);
			e.AddTimer(
				e.enemySpawner.SpawnDelay, 
				e.enemySpawner.SpawnDelay,
				() =>
				{
					StartTimer(e, globals);
				}, false);
		}
	
		private void CreateEnemy(Globals globals, EnemySpawnerComponent spawner)
		{
			GameEntity entity = _contexts.game.CreateEntity();
		
			entity.AddMove(spawner.SpawnPoint.forward * globals.EnemyMovementSpeed);
			entity.AddPosition(spawner.SpawnPoint.position);
			entity.AddRotation(spawner.SpawnPoint.rotation);
			entity.AddHealth(globals.EnemyHealth);
			entity.AddDamageDealer(1, true);
		
			entity.isLookAtMovement = true;
			entity.isEnemy = true;
		
			GameObject enemyView = GameObject.Instantiate(
				spawner.EnemyPrefab,
				spawner.SpawnPoint.position,
				spawner.SpawnPoint.rotation);
		
			if (enemyView.TryGetComponent(out EntityLink link))link.Link(entity);
			else enemyView.AddComponent<EntityLink>().Link(entity);
			entity.AddView(enemyView);
		}
	}
}
