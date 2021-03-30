using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMovementSystem : ReactiveSystem<GameEntity> 
{
    private Contexts _contexts;
    
	public LookAtMovementSystem (Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Rotation);
	}
		
	protected override bool Filter(GameEntity entity)
	{
		return entity.isLookAtMovement;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities) 
		{
			e.ReplaceRotation(Quaternion.LookRotation(e.move.Movement));
		}
	}
}
