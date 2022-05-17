using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class CannonballLauncher : MonoBehaviour
{
    // Rewired assets
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player player;

    [SerializeField] private Transform cannonballLauncher; // reference to the Bullet Launch point
    [SerializeField] private GameObject cannonball; // reference to Bullet prefab object
    [SerializeField] private AudioController audioController; // reference to AudioController for Bullet Fire sound

    private Vector2 fireDirection;
    //   private float fireAngle;      // if we want to rotate a small launcher

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    void Update()
    {
        fireDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //        fireAngle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;

        // Get input for firing the bullet/gun

        if (player.GetButtonDown("Cannon"))
        {
            FireCannonball();
        }
    }


    // Function to call when you get fire bullet input
    private void FireCannonball()
    {
        GameObject firedCannonball = Instantiate(cannonball, cannonballLauncher.position, cannonballLauncher.rotation);       // Instantiate a bullet prefab at the launcher's position and rotation
        firedCannonball.GetComponent<Rigidbody2D>().velocity = fireDirection;

        audioController.CannonballLaunch();
    }

}
