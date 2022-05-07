using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float pressure;
    [SerializeField] private float time = 0f;
    [SerializeField] private float depth = 0f;
    [SerializeField, Range(0f, 1f)] private float ballast = 0f;



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
        ballastInput = Input.GetAxisRaw("Vertical");
        velocity.y = ballast;
        depth = this.transform.position.y;
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * moveSpeed * Time.fixedDeltaTime);
        if (ballastInput > 0f && ballast < 1f)
            ballast += .01f;
        else if (ballastInput < 0f && ballast > 0f)
            ballast -= .01f;
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
