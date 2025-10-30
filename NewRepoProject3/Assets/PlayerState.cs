using UnityEngine;

public class PlayerState
{
    protected PlayerManager player;

    public PlayerState(PlayerManager newPlayer)
    {
        player = newPlayer;
    }

    public virtual void EnterState()
    {

    }

    public virtual void ExitState()
    {

    }

    public virtual void ProcessState(float delta)
    {

    }
}
