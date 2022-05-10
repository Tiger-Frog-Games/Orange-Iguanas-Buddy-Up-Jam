using System;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField] Gradient gradient;                 // Gradient variable to set a gradient from blue to black
    [SerializeField] Color color;                       // Color variable to set the color of the background
    [SerializeField] PlayerController playerController; // Get reference to PlayerController script
    [SerializeField] Camera cameraVariable;             // Camera variable to input the main camera into
    private float depth;                                // Depth variable to get depth from playercontroller script

    // Update is called once per frame
    void Update()
    {
        depth = playerController.GetDepth();                            // Get the depth from the player controller
        float value = Mathf.Lerp(0f, 1f, Math.Abs((depth/1000)));       // lerp the value of the depth 
        color = gradient.Evaluate(value);                               // assign the color variable from the gradient based on depth
        cameraVariable.backgroundColor = color;                         // make the color the background color
    }


}
