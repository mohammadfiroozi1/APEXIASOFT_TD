using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WayPointGetter : MonoBehaviour
{
    [SerializeField] WayPointEventChannel wayPointChannel;

    [SerializeField] List<Transform> wayPoints = new List<Transform>();


    private void OnEnable()
    {
        wayPointChannel.GetValue += GetWayPointList;
    }
    public List<Transform> GetWayPointList() => wayPoints;
}
