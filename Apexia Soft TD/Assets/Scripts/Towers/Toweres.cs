using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toweres : MonoBehaviour
{
    public TowerData data;
    public LayerMask enemyLayer;
    public Transform projectileSpawnPos;
    public TowerBuilderPannelChannel towerBuilderPannelChannel;
    public TowerData TowerData => data;


    public virtual void Update()
    {

    }

    public virtual void FindTarget()
    {
        
    }
    public virtual void Attack()
    {

    }

}
