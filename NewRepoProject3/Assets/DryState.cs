using UnityEngine;

public class DryState : PlayerState
{
    private float timeSinceDry = 0.0f;
    private float timeToGameOver = 3.0f;

    public DryState(PlayerManager newPlayer) : base(newPlayer)
    {

    }

    public override void ProcessState(float delta)
    {
        timeSinceDry += Time.deltaTime;
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * Mathf.Max(0.0f, 1.0f - timeSinceDry) * player.maxSpeed;

        if(timeSinceDry > timeToGameOver)
        {
            if (player.isHighscoreDirty)
            {
                player.highscore = player.transform.position.y;
                PlayerPrefs.SetFloat("highscore", player.highscore);
                player.isHighscoreDirty = false;
                Debug.Log("Your new highscore is " + player.highscore.ToString());
            }
        }
    }
}
