using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float pressure;
    [SerializeField] private float time = 0;
    [SerializeField] private float depth = 0;

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
        velocity.y = Input.GetAxisRaw("Vertical");
        depth = this.transform.position.y;
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + velocity * moveSpeed * Time.fixedDeltaTime);
    }
}
