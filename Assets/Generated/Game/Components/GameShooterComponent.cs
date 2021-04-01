//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ShooterComponent shooter { get { return (ShooterComponent)GetComponent(GameComponentsLookup.Shooter); } }
    public bool hasShooter { get { return HasComponent(GameComponentsLookup.Shooter); } }

    public void AddShooter(UnityEngine.GameObject newView, UnityEngine.Transform newShootPoint, TowerType newType, UnityEngine.Transform newTarget, float newShootDistance, float newShootSpeed) {
        var index = GameComponentsLookup.Shooter;
        var component = (ShooterComponent)CreateComponent(index, typeof(ShooterComponent));
        component.View = newView;
        component.ShootPoint = newShootPoint;
        component.Type = newType;
        component.Target = newTarget;
        component.ShootDistance = newShootDistance;
        component.ShootSpeed = newShootSpeed;
        AddComponent(index, component);
    }

    public void ReplaceShooter(UnityEngine.GameObject newView, UnityEngine.Transform newShootPoint, TowerType newType, UnityEngine.Transform newTarget, float newShootDistance, float newShootSpeed) {
        var index = GameComponentsLookup.Shooter;
        var component = (ShooterComponent)CreateComponent(index, typeof(ShooterComponent));
        component.View = newView;
        component.ShootPoint = newShootPoint;
        component.Type = newType;
        component.Target = newTarget;
        component.ShootDistance = newShootDistance;
        component.ShootSpeed = newShootSpeed;
        ReplaceComponent(index, component);
    }

    public void RemoveShooter() {
        RemoveComponent(GameComponentsLookup.Shooter);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherShooter;

    public static Entitas.IMatcher<GameEntity> Shooter {
        get {
            if (_matcherShooter == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Shooter);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShooter = matcher;
            }

            return _matcherShooter;
        }
    }
}