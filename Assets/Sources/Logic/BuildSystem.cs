using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : ReactiveSystem<GameEntity> 
{
    private Contexts _contexts;
    
	public BuildSystem (Contexts contexts) : base(contexts.game) 
	{
		_contexts = contexts;
	}
		
	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.BuildCommand);
	}
		
	protected override bool Filter(GameEntity entity)
	{
		return true;
	}

	protected override void Execute(List<GameEntity> entities) 
	{
		foreach (var e in entities)
		{
			var buildingEntity = _contexts.game.CreateEntity();
			buildingEntity.AddPosition(e.buildCommand.BuildPlace.position);
			buildingEntity.AddRotation(e.buildCommand.BuildPlace.rotation);
			GameObject building = new GameObject("Tower");
			building.transform.position = e.buildCommand.BuildPlace.position;
			buildingEntity.AddView(building);
			switch (e.buildCommand.BuildingType)
			{
				case BuildingType.ARCHER:
					GameObject.Instantiate(
						_contexts.game.globals.value.ArcherTower, 
						building.transform);
					buildingEntity.AddBuilding(e.buildCommand.BuildingType, e.buildCommand.BuildPlace.gameObject, 
						new GameObject());
					break;
			}
			building.transform.rotation = e.buildCommand.BuildPlace.rotation;
			if (building.TryGetComponent(out EntityLink link))link.Link(buildingEntity);
			else building.AddComponent<EntityLink>().Link(buildingEntity);
			e.buildCommand.BuildPlace.gameObject.SetActive(false);

			e.isDestroyed = true;
		}
	}
}
