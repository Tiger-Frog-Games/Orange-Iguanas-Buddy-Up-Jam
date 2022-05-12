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
    [SerializeField] private Slider happySlider;
    [SerializeField] Gradient happyGradient;
    [SerializeField] private Image happyBar;

    [SerializeField] private Slider ballastSlider;
    [SerializeField] Gradient ballastGradient;
    [SerializeField] private Image ballastBar;

    // Update is called once per frame
    void Update()
    {
        depthText.text = "Depth: " + playerController.GetDepth().ToString("F2");            // Depth display--For now, we're just displaying text, but we'll want to convert some or all of these to meters
        SetBallast();                                         // Ballast display--Having a horizontal meter display it with red in the middle and green on the ends
        SetHappiness();                                    // Happiness display--Having a vertical meter display it with green at the top and yellow in the middle and red at bottom when close to 0
    }

    private void SetHappiness()
    {
        happySlider.value = playerController.GetHappy();
        happyBar.color = happyGradient.Evaluate(happySlider.normalizedValue);
    }

    private void SetBallast()
    {
        ballastSlider.value = playerController.GetBallast();
        ballastBar.color = ballastGradient.Evaluate(ballastSlider.normalizedValue);
    }
}
