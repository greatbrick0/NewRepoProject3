using UnityEngine;

public class DrivingState : PlayerState
{
    public DrivingState(PlayerManager newPlayer) : base(newPlayer)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void ProcessState()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) dir += Vector2.up;
        if (Input.GetKey(KeyCode.S)) dir += Vector2.down;
        if (Input.GetKey(KeyCode.A)) dir += Vector2.left;
        if (Input.GetKey(KeyCode.D)) dir += Vector2.right;

        player.GetComponent<Rigidbody2D>().linearVelocity = dir.normalized * player.maxSpeed;
    }
}
