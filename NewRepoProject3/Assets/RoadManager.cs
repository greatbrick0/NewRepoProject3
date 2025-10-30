using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;
    [SerializeField]
    private GameObject roadObj;
    private List<GameObject> roadRefs = new List<GameObject>();
    private float currentDistance = 0;

    private void Start()
    {
        for(int ii = 0; ii < 3; ii++)
        {
            AddNewRoad();
        }
        playerManager.reachedMilestoneDistance += CycleRoads;
    }

    private void AddNewRoad()
    {
        roadRefs.Add(Instantiate(roadObj, transform));
        roadRefs[roadRefs.Count - 1].transform.position = Vector2.up * currentDistance;
        currentDistance += 10;
    }

    private void CycleRoads()
    {
        AddNewRoad();
    }
}
