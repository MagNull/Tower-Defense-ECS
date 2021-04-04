using Entitas;

namespace Sources.Logic.TowerLogic
{
	public class TowerFindTargetSystem : IExecuteSystem  
	{
		private Contexts _contexts;
		private IGroup<GameEntity> _shooters;
		private IGroup<GameEntity> _enemies;

		public TowerFindTargetSystem(Contexts contexts) 
		{
			_contexts = contexts;
			_shooters = _contexts.game.GetGroup(GameMatcher.Shooter);
			_enemies = _contexts.game.GetGroup(GameMatcher.Enemy);
		}

		public void Execute()
		{
			foreach (var s in _shooters)
			{
				float distance = s.shooter.ShootDistance * s.shooter.ShootDistance;
				if (!s.shooter.Target)
				{
					foreach (var enemy in _enemies)
					{
						if ((enemy.position.Position - s.position.Position).sqrMagnitude <= distance)
						{
							s.shooter.Target = enemy.view.View.transform;
						}
					}
				}
				else if((s.shooter.Target.position - s.position.Position).sqrMagnitude > distance)
				{
					s.shooter.Target = null;
				}
			}
		}
	}
}