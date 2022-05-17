using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class BombLauncher : MonoBehaviour
{
    // Rewired assets
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player player;

    [SerializeField] private Transform bombLauncher; // reference to the Bomb Launch point
    [SerializeField] private GameObject bomb; // reference to Bomb prefab object
    [SerializeField] private AudioController audioController; // reference to AudioController for Bullet Fire sound

    private PlayerController playerController; // reference to PlayerController for Bomb ability

    private Vector2 fireDirection;
    //   private float fireAngle;      // if we want to rotate a small launcher

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerID);
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        fireDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //        fireAngle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;

        // Get input for firing the bullet/gun

        if (player.GetButtonDown("Bomb") && playerController.GetHasBomb())
        {
            FireCannonball();
        }
    }


    // Function to call when you get fire bullet input
    private void FireCannonball()
    {
        Instantiate(bomb, bombLauncher.position, bombLauncher.rotation);       // Instantiate a torpedo prefab at the launcher's position and rotation

        audioController.CannonballLaunch();
    }

}
