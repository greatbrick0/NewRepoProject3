using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float milestoneDistance = 0;
    public delegate void ReachedMilestoneDistance();
    public ReachedMilestoneDistance reachedMilestoneDistance;

    private PlayerState currentState;
    public List<PlayerState> allStates = new List<PlayerState>();

    private void Awake()
    {
        allStates.Add(new PlayerState(this));
        allStates.Add(new PlayerState(this));
        allStates.Add(new PlayerState(this));
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.ProcessState();
        }
        if(transform.position.y > milestoneDistance)
        {
            if(reachedMilestoneDistance != null) reachedMilestoneDistance.Invoke();
        }
    }

    public void ChangeState(int newStateIndex)
    {
        currentState.ExitState();
        currentState = allStates[newStateIndex];
        currentState.EnterState();
    }
}
