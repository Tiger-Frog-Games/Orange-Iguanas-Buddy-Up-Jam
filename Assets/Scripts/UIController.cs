using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;  // reference to PlayerController script to get various player components like depth, ballast, happyMeter, etc.
    [SerializeField] private TMP_Text depthText; // reference to the UI TMP text box for displaying depth
    [SerializeField] private TMP_Text ballastText; // reference to UI TMP text box for displaying ballast info
    [SerializeField] private TMP_Text happyText; // reference to UI TMP text box for displaying happiness meter
    [SerializeField] private TMP_Text dialogueText; // reference to UI TMP text box for displaying character dialogue
    [SerializeField] private Image characterImage; // reference to UI Image for displaying which sprite is talking

    // Update is called once per frame
    void Update()
    {
        depthText.text = "Depth: " + playerController.GetDepth().ToString("F3");            // Depth display--For now, we're just displaying text, but we'll want to convert some or all of these to meters
        ballastText.text = "Ballast: " + playerController.GetBallast().ToString("F1");      // Ballast display--For now, we're just displaying text, but we'll want to convert some or all of these to meters
        happyText.text = "Happy: " + playerController.GetHappy().ToString();                // Happiness display--For now, we're just displaying text, but we'll want to convert some or all of these to meters
    }
}
