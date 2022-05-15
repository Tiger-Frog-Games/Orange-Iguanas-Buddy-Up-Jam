using UnityEngine;
using Rewired;

public class TorpedoLauncher : MonoBehaviour
{
    // Rewired assets
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player player;

    [SerializeField] private Transform torpedoLauncher; // reference to the Torpedo Launch point
    [SerializeField] private GameObject torpedo; // reference to Torpedo prefab object
    [SerializeField] private AudioController audioController; // reference to AudioController for Torpedo Launch sound

    [SerializeField, Range(0f, 5f)] private float cooldownAmount = 5f; // Amount to wait
    private float cooldownTimer;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerID);
        cooldownTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        // Get input for firing the torpedo

        if (player.GetButtonDown("Torpedo") && cooldownTimer <= 0f)
        {
            FireTorpedo();
        }
    }


    // Function to call when you get fire torpedo input
    private void FireTorpedo()
    {
        Instantiate(torpedo, torpedoLauncher.position, torpedoLauncher.rotation);       // Instantiate a torpedo prefab at the launcher's position and rotation
        audioController.TorpedoLaunch();
        cooldownTimer = cooldownAmount;
    }

}
