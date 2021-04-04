using Entitas;

namespace Sources.Logic.EnemyLogic
{
	public class EnemySpawnerInitSystem : IInitializeSystem  
	{
		private Contexts _contexts;

		public EnemySpawnerInitSystem(Contexts contexts) 
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			var globals = _contexts.game.globals.value;
			var spawnerEntity = _contexts.game.CreateEntity();
			spawnerEntity.AddView(_contexts.game.staticViews.EnemySpawner);
			spawnerEntity.AddEnemySpawner(globals.EnemySpawnDelay,
				spawnerEntity.view.View.transform.GetChild(0), 
				globals.EnemyPrefab);
		}		
	}
}