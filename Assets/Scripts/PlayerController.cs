using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Range(10f, 50f)] private float moveSpeed = 15f;
    [SerializeField] private float pressure;
    [SerializeField] private float time = 0f;
    [SerializeField] private float depth = 0f;
    [SerializeField, Range(-0.5f, .5f)] private float ballast = 0f;



    private float ballastInput;

    private Vector2 velocity;
    private Rigidbody2D body;

    // Start is called before the first frame update
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");
        ballastInput = Input.GetAxis("Vertical");
        if (ballast >= -.1f && ballast <= .1f)
            velocity.y = 0;
        else
            velocity.y = ballast;
        depth = this.transform.position.y;
        Debug.Log(ballastInput);
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * moveSpeed * Time.fixedDeltaTime);
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
    }

    public float GetDepth()
    {
        return depth;
    }

    public float GetBallast()
    {
        return ballast;
    }
}
