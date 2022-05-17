using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField, Range(1f, 50f)] private float speed = 40f;

    private Rigidbody2D body;
    private GameObject audioControllerObject;
    private GameObject playerObject;
    private AudioController audioController;

    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        audioControllerObject = GameObject.FindWithTag("AudioController");
        audioController = audioControllerObject.GetComponent<AudioController>();
        playerObject = GameObject.FindWithTag("Player");

        body = GetComponent<Rigidbody2D>();
        body.velocity = body.velocity * speed;
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), playerObject.GetComponent<PolygonCollider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            health = collision.gameObject.GetComponent<Health>();
            health.DecreaseHealthByFive();

        }
        Destroy(gameObject);
        audioController.CannonballImpact();
    }
}
