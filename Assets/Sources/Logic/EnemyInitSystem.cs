using Entitas;
using UnityEngine;

namespace Sources.Logic
{
	public class EnemyInitSystem : IInitializeSystem  
	{
		private Contexts _contexts;

		public EnemyInitSystem(Contexts contexts) 
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var globals = _contexts.game.globals.value;
			for (int i = 0; i < 1; i++)
			{
				GameEntity entity = _contexts.game.CreateEntity();
				entity.AddMove(Vector3.right);
				entity.AddPosition(Vector3.zero);
				entity.AddRotation(Quaternion.identity);
				entity.AddHealth(10);
				entity.isLookAtMovement = true;
				entity.isEnemy = true;
			}
		}		
	}
}