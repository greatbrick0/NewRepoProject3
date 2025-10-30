using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed { get; private set; } = 5.0f;
    public float milestoneDistance = -10;
    public delegate void ReachedMilestoneDistance();
    public ReachedMilestoneDistance reachedMilestoneDistance;

    private PlayerState currentState;
    public List<PlayerState> allStates = new List<PlayerState>();

    private void Awake()
    {
        allStates.Add(new DrivingState(this));
        allStates.Add(new PlayerState(this));
        allStates.Add(new PlayerState(this));
        currentState = allStates[0];
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
