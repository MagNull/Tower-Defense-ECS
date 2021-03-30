using Entitas;
using System.Collections.Generic;

public class ViewRotationSystem : ReactiveSystem<GameEntity> 
{
    private Contexts _contexts;
    
	public ViewRotationSystem (Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Rotation);
	}
		
	protected override bool Filter(GameEntity entity)
	{
		return entity.hasView;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			e.view.View.transform.rotation = e.rotation.Rotation;
		}
	}
}
