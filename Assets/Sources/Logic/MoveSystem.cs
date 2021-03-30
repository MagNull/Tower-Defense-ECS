using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem  
{
	private Contexts _contexts;
	private IGroup<GameEntity> _group;

    public MoveSystem(Contexts contexts) 
    {
    	_contexts = contexts;
        _group = _contexts.game.GetGroup(GameMatcher.Move);
    }

	public void Execute()
	{
		foreach (var entity in _group)
		{
			Vector3 newPosition = entity.position.Position + entity.move.Movement * Time.deltaTime;
			entity.ReplacePosition(newPosition);
		}
	}
}