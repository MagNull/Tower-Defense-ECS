using System;
using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBalanceSystem : ReactiveSystem<GameEntity> 
{
    private Contexts _contexts;
    
	public PlayerBalanceSystem (Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		return context.CreateCollector(GameMatcher.ChangeBalance);
	}
		
	protected override bool Filter(GameEntity entity)
	{
		return true;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			int newBalance = _contexts.game.playerEntity.playerBalance.Balance + e.changeBalance.Value;
			newBalance = Mathf.Clamp(newBalance, 0, int.MaxValue);
			_contexts.game.playerEntity.ReplacePlayerBalance(newBalance);
		}
	}
}
