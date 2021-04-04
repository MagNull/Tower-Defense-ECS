using Entitas;
using UnityEngine;

namespace Sources.Logic.GeneralLogic
{
	public class LookAtTargetSystem : IExecuteSystem  
	{
		private Contexts _contexts;
		private IGroup<GameEntity> _group;

		public LookAtTargetSystem(Contexts contexts) 
		{
			_contexts = contexts;
			_group = contexts.game.GetGroup(GameMatcher.Shooter);
		}

		public void Execute()
		{
			foreach (var entity in _group)
			{
				if (entity.shooter.Type == TowerType.ARCHER && entity.shooter.Target)
				{
					Vector3 lookDirection = (entity.shooter.Target.position - entity.position.Position).normalized;
					entity.shooter.View.transform.rotation = Quaternion.LookRotation(lookDirection);
				}
			}
		}
	}
}