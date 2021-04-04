using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic.TowerLogic
{
	public class ShowBuildPanelSystem : ReactiveSystem<GameEntity> 
	{
		private Contexts _contexts;
		private BuildPanel _panel;
    
		public ShowBuildPanelSystem (Contexts contexts) : base(contexts.game) 
		{
			_contexts = contexts;
			_panel = _contexts.game.uIElements.BuildPanel;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.BuildingClick, 
				GameMatcher.NormalClick));
		}
		
		protected override bool Filter(GameEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameEntity> entities) 
		{
			if (!_contexts.game.globals.value.IsPaused)
			{
				foreach (var e in entities)
				{
					if(e.isNormalClick) _panel.HidePanel();
					else _panel.ShowPanel(e.buildingClick);
					e.isDestroyed = true;
				}
			}
		}
	}
}
