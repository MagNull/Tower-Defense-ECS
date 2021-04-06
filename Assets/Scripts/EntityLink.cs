using System;
using UnityEngine;

public class EntityLink : MonoBehaviour
{
    private GameEntity _linkedEntity;

    public GameEntity LinkedEntity => _linkedEntity;

    public void Link(GameEntity entity) => _linkedEntity = entity;
    
}