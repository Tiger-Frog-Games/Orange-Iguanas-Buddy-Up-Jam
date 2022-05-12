using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoLauncher : MonoBehaviour
{

    [SerializeField] private Transform torpedoLauncher; // reference to the Torpedo Launch point
    [SerializeField] private GameObject torpedo; // reference to Torpedo prefab object
    [SerializeField] private AudioController audioController; // reference to AudioController for Torpedo Launch sound

    // Update is called once per frame
    void Update()
    {
        // Get input for firing the torpedo

        if (Input.GetButtonDown("Fire2"))
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
