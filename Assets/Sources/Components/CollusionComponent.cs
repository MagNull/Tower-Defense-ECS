using Entitas;

[Game]
public class CollusionComponent : IComponent
{
    public GameEntity CollusionEmitter;
    public GameEntity Other;
}