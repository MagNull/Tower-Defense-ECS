using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShootSystem : ReactiveSystem<GameEntity> 
{
    private Contexts _contexts;
    
	public ArcherShootSystem (Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Shooter);
	}
		
	protected override bool Filter(GameEntity entity)
	{
		return entity.shooter.Type == TowerType.ARCHER;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			if (!e.hasTimer)
				e.AddTimer(_contexts.game.globals.value.ArcherShootDelay, 
					_contexts.game.globals.value.ArcherShootDelay, () =>
				{
					CreateArrow(e);
				}, true);
		}
	}
	
	private void CreateArrow(GameEntity e)
	{
		if (e.shooter.Target)
		{
			var globals = _contexts.game.globals.value;
			GameEntity arrowEntity = _contexts.game.CreateEntity();
			
			arrowEntity.AddPosition(e.shooter.ShootPoint.position);
			Vector3 arrowDirection = (e.shooter.Target.position - arrowEntity.position.Position).normalized *
			                         globals.ArrowSpeed;
			arrowEntity.AddMove(arrowDirection);
			arrowEntity.AddRotation(Quaternion.LookRotation(arrowDirection));
			arrowEntity.AddDamageDealer(1);
			
			GameObject arrow = GameObject.Instantiate(globals.ArrowPrefab,
				e.shooter.ShootPoint.position, Quaternion.LookRotation(arrowDirection));
			arrow.AddComponent<EntityLink>().Link(arrowEntity);
			arrowEntity.AddView(arrow);
			
			arrowEntity.isLookAtMovement = true;
		}
	}
}
