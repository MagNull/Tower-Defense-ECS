using System.Collections.Generic;
using Entitas;

namespace Sources.Logic.GeneralLogic
{
	public class DamageSystem : ReactiveSystem<GameEntity> 
	{
		private Contexts _contexts;
    
		public DamageSystem (Contexts contexts) : base(contexts.game) 
		{
			_contexts = contexts;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Collusion);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.collusion.CollusionEmitter.hasDamageDealer;
		}

		protected override void Execute(List<GameEntity> entities) 
		{
			foreach (var e in entities)
			{
				GameEntity damageEntity = e.collusion.CollusionEmitter;
				if (e.collusion.Other == null && damageEntity.damageDealer.DestroyAfterDamage)
				{
					damageEntity.isDestroyed = true;
				}
				else
				{
					if (e.collusion.Other.hasHealth)
					{
						int newHealth = e.collusion.Other.health.Value 
						                - damageEntity.damageDealer.Damage;
						e.collusion.Other.ReplaceHealth(newHealth);
						if(damageEntity.damageDealer.DestroyAfterDamage)damageEntity.isDestroyed = true;
					}
				}
				e.isDestroyed = true;
			}
		}
	}
}
