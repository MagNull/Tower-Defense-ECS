using Entitas;
using UnityEngine;

namespace Sources.Logic.PlayerLogic
{
	public class PlayerInitSystem : IInitializeSystem  
	{
		private Contexts _contexts;

		public PlayerInitSystem(Contexts contexts) 
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			GameEntity entity = _contexts.game.CreateEntity();
			GameObject playerView = _contexts.game.staticViews.PlayerHealth;
			if (playerView.TryGetComponent(out EntityLink link))
			{
				link.Link(entity);
			}
			else
			{
				playerView.AddComponent<EntityLink>().Link(entity);
			}
			entity.AddView(playerView);
			entity.AddHealth(_contexts.game.globals.value.PlayerHealth);
			entity.AddPlayerBalance(_contexts.game.globals.value.PlayerBalance);
			_contexts.game.uIElements.KillCountText.text = "0";
			entity.isPlayer = true;
		}		
	}
}