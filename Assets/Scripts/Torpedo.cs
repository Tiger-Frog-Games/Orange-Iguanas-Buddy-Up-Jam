using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    [SerializeField, Range(1f, 50f)] private float speed = 20f;

    private Rigidbody2D body;
    private GameObject audioControllerObject;
    private GameObject playerObject;
    private AudioController audioController;

    // Start is called before the first frame update
    void Start()
    {
        audioControllerObject = GameObject.FindWithTag("AudioController");
        audioController = audioControllerObject.GetComponent<AudioController>();
        playerObject = GameObject.FindWithTag("Player");

        body = GetComponent<Rigidbody2D>();
        body.velocity = transform.right * speed;
//        Physics.IgnoreCollision(Torpedo.GetComponent<CapsuleCollider2D>, playerObject.GetComponent<CapsuleCollider2D>);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);

        }    
            
        Destroy(gameObject);
        audioController.TorpedoImpact();
    }

}
