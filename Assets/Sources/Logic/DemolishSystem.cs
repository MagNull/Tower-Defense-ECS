using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic
{
	public class DemolishSystem : ReactiveSystem<GameEntity> 
	{
		private Contexts _contexts;
    
		public DemolishSystem (Contexts contexts) : base(contexts.game) 
		{
			_contexts = contexts;
		}
		
		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Demolish);
		}
		
		protected override bool Filter(GameEntity entity)
		{
			return true;
		}

		protected override void Execute(List<GameEntity> entities) 
		{
			foreach (var e in entities) 
			{
				GameObject.Destroy(e.view.View);
				GameObject demolishView = GameObject.Instantiate(
					_contexts.game.globals.value.ArcherTowerConstruct,
					e.position.Position,
					e.rotation.Rotation
				);
				demolishView.GetComponentInChildren<ParticleSystem>().Play();
				e.RemoveShooter();
				e.ReplaceView(demolishView);
			
				e.ReplaceTimer(3,3, () =>
				{
					e.building.BuildingBase.SetActive(true);
					e.isDestroyed = true;
				}, false);
			}
		}
	}
}
