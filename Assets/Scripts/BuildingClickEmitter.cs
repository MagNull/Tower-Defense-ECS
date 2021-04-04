using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClickEmitter : MonoBehaviour
{
    [SerializeField] private bool _isBuilding;
    [SerializeField] private bool _isBuildPlace;
    private Contexts _contexts;

    private void Start()
    {
        _contexts = Contexts.sharedInstance;
    }
    
    private void OnMouseDown()
    {
        if (_isBuildPlace || _isBuilding) _contexts.game.CreateEntity().AddBuildingClick(transform, Input.mousePosition, _isBuilding);
        else _contexts.game.CreateEntity().isNormalClick = true;

    }
}
