using System.Collections.Generic;
using Entitas;

namespace Sources.Logic.GeneralLogic
{
	public class ViewPositionSystem : ReactiveSystem<GameEntity> 
	{
		private Contexts _contexts;
    
		public ViewPositionSystem (Contexts contexts) : base(contexts.game) 
		{
			_contexts = contexts;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Position);
		}
		
		protected override bool Filter(GameEntity entity)
		{
			return entity.hasView;
		}

		protected override void Execute(List<GameEntity> entities) 
		{
			foreach (var e in entities)
			{
				e.view.View.transform.position = e.position.Position;
			}
		}
	}
}
