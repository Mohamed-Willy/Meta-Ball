using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public enum Axis
{
    X,
    Y, 
    Z
}
[Serializable]
public class MovingObj
{
    public Axis axis;
    public float offsite;
    public Transform transform;
}
public class TableMover : MonoBehaviour
{
    Transform _Transform;
    [SerializeField] List<MovingObj> movers;
    private void Start()
    {
        _Transform = transform;
        for (int i = 0; i < movers.Count; i++)
        {
            if (movers[i].axis == Axis.X)
                movers[i].offsite = _Transform.position.x - movers[i].transform.position.x;
            if (movers[i].axis == Axis.Y)
                movers[i].offsite = _Transform.position.y - movers[i].transform.position.y;
            if (movers[i].axis == Axis.Z)
                movers[i].offsite = _Transform.position.z - movers[i].transform.position.z;
        }
    }
    void Update()
    {
        for (int i = 0; i < movers.Count; i++)
        {
            if (movers[i].axis == Axis.X)
                _Transform.position = new(movers[i].offsite + movers[i].transform.position.x, _Transform.position.y, _Transform.position.z);
            if (movers[i].axis == Axis.Y)
                _Transform.position = new(_Transform.position.x, movers[i].offsite + movers[i].transform.position.y, _Transform.position.z);
            if (movers[i].axis == Axis.Z)
                _Transform.position = new(_Transform.position.x, _Transform.position.y, movers[i].offsite + movers[i].transform.position.z);
        }
    }
}
