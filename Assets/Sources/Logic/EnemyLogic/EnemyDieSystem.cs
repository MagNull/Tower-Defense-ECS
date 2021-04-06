using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic.EnemyLogic
{
	public class EnemyDieSystem : ReactiveSystem<GameEntity> 
	{
		private Contexts _contexts;
    
		public EnemyDieSystem (Contexts contexts) : base(contexts.game) 
		{
			_contexts = contexts;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Health);
		}
		
		protected override bool Filter(GameEntity entity)
		{
			return entity.health.Value <= 0 && entity.isEnemy;
		}

		protected override void Execute(List<GameEntity> entities) 
		{
			foreach (var e in entities)
			{
				_contexts.game.globals.value.KillCount++;
				_contexts.game.uIElements.KillCountText.text = _contexts.game.globals.value.KillCount.ToString();
				_contexts.game.CreateEntity().AddChangeBalance(1);
				e.isDestroyed = true;
			}
		}
	}
}
