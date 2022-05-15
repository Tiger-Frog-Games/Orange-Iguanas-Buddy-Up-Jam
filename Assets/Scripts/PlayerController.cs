using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class PlayerController : MonoBehaviour
{
    // Rewired assets
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player player;

    [SerializeField, Range(0f, 10f)] private float moveSpeed = 1f;      // Movement Speed variable, higher moves faster
    [SerializeField] private float pressure;                            // Pressure variable, currently not using
    [SerializeField] private float time = 0f;                           // Time variable, currently not using
    [SerializeField] private float depth = 0f;                          // Depth variable, tracks how deep the sub is using y coordinate
    [SerializeField, Range(-0.5f, .5f)] private float ballast = 0f;     // Ballast variable, between -.5 and .5, where -.1 to .1 don't move and others move up or down
    [SerializeField, Range(0,20)] private int happyMeter = 20;          // Happiness variable, as it goes down to 0 the crew gets unhappy, 20 is max and reset when you party
    [SerializeField] private GameObject torpedoLauncher;                // Reference to torpedo launcher to flip it as well
    
    private float ballastInput;                                         // Float to take in input for ballast (vertical movement)
    
    private float happyTimer;                                           // Float for the timer for the party meter to go down   
    private bool partyInput;                                            // Boolean variable to track whether party button is pushed 

    private bool facingRight = true;                                    // Boolean variable to track whether sub is facing left or right  
    private Vector2 velocity;                                           // Vector2 for affecting movement   
    private Rigidbody2D body;                                           // Variable for reference to rigidbody of submarine
    private Health health;

    private float collisionTime = 0f;
    private float collisionTimeThreshold = 2f;

    // Start is called before the first frame update
    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerID);
        body = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();    
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = player.GetAxisRaw("MoveHorizontal");    // gets input for horizontal movement
        ballastInput = player.GetAxis("MoveVertical");       // gets input for vertical movement
        partyInput = player.GetButtonDown("Party");      // gets input for Party action
        if (ballast >= -.1f && ballast <= .1f)          // if the ballast is between -.1 and .1 there is no vertical movement (aside from gravity)
            velocity.y = 0;
        else
            velocity.y = ballast;                       // if the ballast is outside of that range, vertical movement changes accordingly
        depth = this.transform.position.y;              // we get the depth from the players y transform position
        happyTimer += Time.deltaTime;                   // the happiness timer is updated with time
    }

    private void FixedUpdate()
    {
        // Move the submarine
        body.MovePosition(body.position + velocity * moveSpeed * Time.fixedDeltaTime);
        
        // if the value of ballast is within the moveable bounds, then the player can add or subtract with input
        if (ballast >= -0.5f && ballast <= .5f)
        {
            if (ballastInput == -1f)
                ballast -= .01f;
            else if (ballastInput == 1f)
                ballast += .01f;
        }
        else if (ballast < -.5f)
            ballast = -.5f;
        else if (ballast > .5f)
            ballast = .5f;

        // if we're moving left and right, make sure we flip the submarine sprite to show it
        if (velocity.x > 0 && !facingRight || velocity.x < 0 && facingRight)
            FlipSub();         

        // if the happy timer is at 0, happyMeter should be full, otherwise it should depreciate with time
        if (happyTimer == 0)                        
            happyMeter = 20;
        else
            happyMeter = 20 - Convert.ToInt32(happyTimer);

        if (partyInput)
            Party();
    }

    private void FlipSub()
    {

        // Check if facing right or left, and flip the submarine
        if (facingRight)
        {
            this.transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }

        // flip the Torpedo Launcher
        torpedoLauncher.transform.Rotate(0f, 180f, 0f);

        // Change the value of the facingRight boolean
        facingRight = !facingRight;
    }

    // Party function, when you press party button this resets the happyTimer and puts the meter back to full
    public void Party()
    {
        happyTimer = 0;
        happyMeter = 20;
    }

    // Collision dector
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && health.GetCurrentHealth() > 1)   // If you have more than 1 health left and collide with enemey, health decreses
        {
                collisionTime = 0f;
                health.DecreaseHealthByOne();
        }
        else if (collision.gameObject.tag == "Enemy" && health.GetCurrentHealth() == 1) // If you only have one health left and collide with enemy, END OF GAME!!!
        {
            // Probably we want to change this to actually display some text, THEN load that scene when you push a button but for now...
            SceneManager.LoadScene(0);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collisionTime < collisionTimeThreshold)
            {
                collisionTime += Time.deltaTime;
            }
            else
            {
                if (health.GetCurrentHealth() > 1)
                {
                    health.DecreaseHealthByOne();
                }
                else if (health.GetCurrentHealth() == 1)
                {
                    // Logic here for Game Over screen and THEN
                    SceneManager.LoadScene(0);
                }
                collisionTime = 0f;
            }
        }      
    }



    // Getter function for depth
    public float GetDepth()
    {
        if (depth >= 0f)                // make sure depth isn't above 0 on UI, if it is, just return 0
            return 0f; 
        else                            // otherwise return the value of depth
            return depth;
    }

    // Getter function for ballast
    public float GetBallast()   
    {
        return ballast;
    }

    // Getter function for happiness
    public int GetHappy()
    {
        if (happyMeter <= 0)            // make sure happiness meter doesn't go below 0 on UI
            return 0;
        else                            // otherwise return the value of the happyMeter
            return happyMeter;
    }
}
