using Entitas;
using System.Collections.Generic;
using TMPro;

public class PlayerBalanceViewSystem : ReactiveSystem<GameEntity> 
{
    private Contexts _contexts;
    private TextMeshProUGUI _balanceText;
    
	public PlayerBalanceViewSystem (Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
		_balanceText = _contexts.game.uIElements.BalanceText;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.PlayerBalance);
	}
		
	protected override bool Filter(GameEntity entity)
	{
		return entity.playerBalance.Balance >= 0;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			_balanceText.text = e.playerBalance.Balance.ToString();
		}
	}
}
