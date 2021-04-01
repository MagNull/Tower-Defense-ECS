using Entitas;
using System.Collections.Generic;

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
		return entity.collusion.Entity1.hasDamageDealer;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			GameEntity damageEntity = e.collusion.Entity1;
			if (e.collusion.Entity2 != null)
			{
				if (e.collusion.Entity2.hasHealth) e.collusion.Entity2.health.Value 
					-= damageEntity.damageDealer.Damage;
			}
			damageEntity.isDestroyed = true;
			e.isDestroyed = true;

		}
	}
}
