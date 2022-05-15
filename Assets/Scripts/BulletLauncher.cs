using UnityEngine;
using Rewired;

public class BulletLauncher : MonoBehaviour
{
    // Rewired assets
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player player;

    [SerializeField] private Transform bulletLauncher; // reference to the Bullet Launch point
    [SerializeField] private GameObject bullet; // reference to Bullet prefab object
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

        if (player.GetButtonDown("Gun"))
        {
            FireBullet();
        }
    }


    // Function to call when you get fire bullet input
    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, bulletLauncher.position, bulletLauncher.rotation);       // Instantiate a bullet prefab at the launcher's position and rotation
        firedBullet.GetComponent<Rigidbody2D>().velocity = fireDirection;
        
        audioController.BulletLaunch();
    }

}
