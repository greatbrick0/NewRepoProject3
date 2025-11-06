using UnityEngine;

public class DrivingState : PlayerState
{
    private float fuel = 0.0f;

    public DrivingState(PlayerManager newPlayer) : base(newPlayer)
    {

    }

    public override void EnterState()
    {
        fuel = 120.0f;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void ProcessState(float delta)
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) dir += Vector2.up;
        if (Input.GetKey(KeyCode.S)) dir += Vector2.down;
        if (Input.GetKey(KeyCode.A)) dir += Vector2.left;
        if (Input.GetKey(KeyCode.D)) dir += Vector2.right;

        player.GetComponent<Rigidbody2D>().linearVelocity = dir.normalized * player.maxSpeed;

        if (Input.GetKeyDown(KeyCode.K)) fuel = 0.0f;
        if (dir.magnitude > 0)
        {
            fuel -= delta;
            //Debug.Log(fuel);
            if (fuel <= 0) player.ChangeState(1);
        }
    }
}
