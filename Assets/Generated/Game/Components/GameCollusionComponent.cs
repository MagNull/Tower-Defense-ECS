//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CollusionComponent collusion { get { return (CollusionComponent)GetComponent(GameComponentsLookup.Collusion); } }
    public bool hasCollusion { get { return HasComponent(GameComponentsLookup.Collusion); } }

    public void AddCollusion(GameEntity newCollusionEmitter, GameEntity newOther) {
        var index = GameComponentsLookup.Collusion;
        var component = (CollusionComponent)CreateComponent(index, typeof(CollusionComponent));
        component.CollusionEmitter = newCollusionEmitter;
        component.Other = newOther;
        AddComponent(index, component);
    }

    public void ReplaceCollusion(GameEntity newCollusionEmitter, GameEntity newOther) {
        var index = GameComponentsLookup.Collusion;
        var component = (CollusionComponent)CreateComponent(index, typeof(CollusionComponent));
        component.CollusionEmitter = newCollusionEmitter;
        component.Other = newOther;
        ReplaceComponent(index, component);
    }

    public void RemoveCollusion() {
        RemoveComponent(GameComponentsLookup.Collusion);
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

    static Entitas.IMatcher<GameEntity> _matcherCollusion;

    public static Entitas.IMatcher<GameEntity> Collusion {
        get {
            if (_matcherCollusion == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Collusion);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollusion = matcher;
            }

            return _matcherCollusion;
        }
    }
}
