using Entitas;

[Game]
public class DamageDealerComponent : IComponent
{
    public int Damage;
    public bool DestroyAfterDamage;
}