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
    private Stack<GameObject> roadPool = new Stack<GameObject>();

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
        roadRefs.Add(GetNewRoad());
        roadRefs[roadRefs.Count - 1].transform.position = Vector2.up * currentDistance;
        currentDistance += 10;
        playerManager.milestoneDistance += 10;
    }

    private GameObject GetNewRoad()
    {
        GameObject output;
        if (roadPool.Count > 0)
        {
            output = roadPool.Pop();
            output.SetActive(true);
        }
        else
        {
            output = Instantiate(roadObj, transform);
            Debug.Log("Instantiation case");
        }
        return output;
    }

    private void DeactivateRoad(GameObject rr)
    {
        rr.SetActive(false);
        roadPool.Push(rr);
    }

    private void CycleRoads()
    {
        AddNewRoad();
        DeactivateRoad(roadRefs[0]);
        roadRefs.RemoveAt(0);
    }
}
