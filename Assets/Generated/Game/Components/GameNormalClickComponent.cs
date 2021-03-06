//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly NormalClickComponent normalClickComponent = new NormalClickComponent();

    public bool isNormalClick {
        get { return HasComponent(GameComponentsLookup.NormalClick); }
        set {
            if (value != isNormalClick) {
                var index = GameComponentsLookup.NormalClick;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : normalClickComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherNormalClick;

    public static Entitas.IMatcher<GameEntity> NormalClick {
        get {
            if (_matcherNormalClick == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NormalClick);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNormalClick = matcher;
            }

            return _matcherNormalClick;
        }
    }
}
