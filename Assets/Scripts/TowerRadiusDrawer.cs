using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityLink))]
public class TowerRadiusDrawer : MonoBehaviour
{
    private EntityLink _link;

    private void Start()
    {
        _link = GetComponent<EntityLink>();
    }

    private void OnDrawGizmos()
    {
        if (!(_link.LinkedEntity is null))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_link.LinkedEntity.position.Position,
                                    _link.LinkedEntity.shooter.ShootDistance);
        }
    }
}
