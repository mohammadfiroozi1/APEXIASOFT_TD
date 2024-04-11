using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Channels/WayPoints Event Channel", fileName = "WayPoints Event Channel")]
public class WayPointEventChannel : ObjectDelegate<List<Transform>>
{

}

public class ObjectDelegate<T> : ScriptableObject
{
    public delegate T ValueDelegate();
    public ValueDelegate GetValue;
}
