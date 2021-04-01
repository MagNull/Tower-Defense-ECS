using System.Collections.Generic;
using Entitas;

namespace Sources.Logic
{
	public class ShowBuildPanelSystem : ReactiveSystem<GameEntity> 
	{
		private Contexts _contexts;
		private BuildPanel _panel;
    
		public ShowBuildPanelSystem (Contexts contexts, BuildPanel panel) : base(contexts.game) 
		{
			_contexts = contexts;
			_panel = panel;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.BuildingClick);
		}
		
		protected override bool Filter(GameEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameEntity> entities) 
		{
			foreach (var e in entities)
			{
				_panel.ShowPanel(e.buildingClick);
				e.isDestroyed = true;
			}
		}
	}
}
