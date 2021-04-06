using Entitas;

public class EmptyEntityDestroySystem : IExecuteSystem  
{
	private Contexts _contexts;
	private IGroup<GameEntity> _group;

    public EmptyEntityDestroySystem(Contexts contexts) 
    {
    	_contexts = contexts;
    }

	public void Execute()
	{
		var entities = _contexts.game.GetEntities();
		for (int i = 0; i < entities.Length; i++)
		{
			if(entities[i].componentPools.Length == 0) entities[i].Destroy();
		}

	}
}
