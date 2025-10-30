using UnityEngine;

public class DryState : PlayerState
{
    private float timeSinceDry = 0.0f;

    public DryState(PlayerManager newPlayer) : base(newPlayer)
    {

    }

    public override void ProcessState(float delta)
    {
        timeSinceDry += Time.deltaTime;
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * Mathf.Max(0.0f, 1.0f - timeSinceDry) * player.maxSpeed;
    }
}
