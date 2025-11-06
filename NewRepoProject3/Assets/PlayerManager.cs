using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed { get; private set; } = 5.0f;
    public float milestoneDistance = -10;
    public float highscore = 0.0f;
    public bool isHighscoreDirty = false;
    public delegate void ReachedMilestoneDistance();
    public ReachedMilestoneDistance reachedMilestoneDistance;

    private PlayerState currentState;
    public List<PlayerState> allStates = new List<PlayerState>();

    private void Awake()
    {
        allStates.Add(new DrivingState(this));
        allStates.Add(new DryState(this));
        currentState = allStates[0];
        currentState.EnterState();

        highscore = PlayerPrefs.GetFloat("highscore");
        Debug.Log(highscore);
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.ProcessState(Time.deltaTime);
        }
        if (!isHighscoreDirty)
        {
            isHighscoreDirty = (transform.position.y > highscore);
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
