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

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for firing the torpedo

        if (player.GetButtonDown("Torpedo"))
        {
            FireTorpedo();
        }
    }


    // Function to call when you get fire torpedo input
    private void FireTorpedo()
    {
        Instantiate(torpedo, torpedoLauncher.position, torpedoLauncher.rotation);       // Instantiate a torpedo prefab at the launcher's position and rotation
        audioController.TorpedoLaunch();
    }

}
