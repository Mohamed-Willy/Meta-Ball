using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public enum Model
{
    Distance,
    BallSize
}
[Serializable]
public class CameraData
{
    [ReadOnly] public bool isActive;
    public Vector2 camPosition;
    public float ballSize;
}
public class DistanceModel
{
    public static void FindCam(List<CameraData> cameraData, Vector2 BallPos)
    {
        int indx = 0;
        float minDis = float.PositiveInfinity;
        for (int i = 0; i < cameraData.Count; i++) {
            cameraData[i].isActive = false;
            if (minDis >= Vector2.Distance(BallPos, cameraData[i].camPosition))
            {
                indx = i;
                minDis = Vector2.Distance(BallPos, cameraData[i].camPosition);
            }
        }
        cameraData[indx].isActive = true;
    }
}
public class SizeModel
{
    public static void FindCam(List<CameraData> cameraData)
    {
        int indx = 0;
        float maxSize = float.NegativeInfinity;
        for (int i = 0; i < cameraData.Count; i++)
        {
            cameraData[i].isActive = false;
            if (cameraData[i].ballSize >= maxSize)
            {
                indx = i;
                maxSize = cameraData[i].ballSize;
            }
        }
        cameraData[indx].isActive = true;
    }
}
public class ViewManager : MonoBehaviour
{
    [SerializeField] Model model;
    [Space(70)]
    [SerializeField] Vector2 BallPos;
    [Space]
    [SerializeField] List<CameraData> cameras;
    private void Update()
    {
        if (model == Model.Distance)
        {
            DistanceModel.FindCam(cameras, BallPos);
        }
        else if (model == Model.BallSize)
        {
            SizeModel.FindCam(cameras);
        }
    }
}