using Entitas;
using System.Collections.Generic;

public class PlayerLoseSystem : ReactiveSystem<GameEntity> 
{
    private Contexts _contexts;
    
	public PlayerLoseSystem (Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Health);
	}
		
	protected override bool Filter(GameEntity entity)
	{
		return entity.isPlayer && entity.health.Value <= 0;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			_contexts.game.globals.value.IsPaused = true;
			_contexts.game.uIElements.LoosePanel.SetActive(true);
			_contexts.game.uIElements.BuildPanel.gameObject.SetActive(false);
		}
	}
}
