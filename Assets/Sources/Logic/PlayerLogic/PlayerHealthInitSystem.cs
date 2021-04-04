using Entitas;
using UnityEngine;

namespace Sources.Logic.PlayerLogic
{
	public class PlayerHealthInitSystem : IInitializeSystem  
	{
		private Contexts _contexts;

		public PlayerHealthInitSystem(Contexts contexts) 
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			GameEntity playerHealthEntity = _contexts.game.CreateEntity();
			GameObject playerView = _contexts.game.staticViews.PlayerHealth;
			if (playerView.TryGetComponent(out EntityLink link))
			{
				link.Link(playerHealthEntity);
			}
			else
			{
				playerView.AddComponent<EntityLink>().Link(playerHealthEntity);
			}
			playerHealthEntity.AddView(playerView);
			playerHealthEntity.AddHealth(_contexts.game.globals.value.PlayerHealth);
			playerHealthEntity.isPlayer = true;
		}		
	}
}