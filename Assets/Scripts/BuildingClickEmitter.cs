using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClickEmitter : MonoBehaviour
{
    [SerializeField] private bool _isBuilding;
    private Contexts _contexts;

    private void Start()
    {
        _contexts = Contexts.sharedInstance;
    }
    
    private void OnMouseDown()
    {
        _contexts.game.CreateEntity().AddBuildingClick(transform, Input.mousePosition, _isBuilding);
    }
}
