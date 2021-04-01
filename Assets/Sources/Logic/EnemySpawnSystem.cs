using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic
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
			return context.CreateCollector(GameMatcher.Enemy);
		}
		
		protected override bool Filter(GameEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var globals = _contexts.game.globals.value;
			foreach (var e in entities)
			{
				e.ReplacePosition(globals.EnemySpawnPoint.position);
				GameObject enemyView = GameObject.Instantiate(globals.EnemyPrefab);
				if (enemyView.TryGetComponent(out EntityLink link))link.Link(e);
				else enemyView.AddComponent<EntityLink>().Link(e);
				e.AddView(enemyView);
			}
		}
	}
}
