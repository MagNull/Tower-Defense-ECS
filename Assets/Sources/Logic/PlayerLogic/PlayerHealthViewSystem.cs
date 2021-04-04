using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic.PlayerLogic
{
	public class PlayerHealthViewSystem : ReactiveSystem<GameEntity> 
	{
		private Contexts _contexts;
    
		public PlayerHealthViewSystem (Contexts contexts) : base(contexts.game) 
		{
			_contexts = contexts;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Health);
		}
		
		protected override bool Filter(GameEntity entity)
		{
			return entity.isPlayer;
		}

		protected override void Execute(List<GameEntity> entities) 
		{
			foreach (var e in entities)
			{
				var slider = _contexts.game.uIElements.PlayerHealthSlider;
				slider.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
					32 * _contexts.game.globals.value.PlayerHealth);
				slider.SetValue(e.health.Value,
					_contexts.game.globals.value.PlayerHealth);
			}
		}
	}
}
