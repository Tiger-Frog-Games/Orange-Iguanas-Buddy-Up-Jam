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
    [SerializeField] private TMP_Text healthText; // reference to UI TMP text box for displaying health info
    [SerializeField] private TMP_Text happyText; // reference to UI TMP text box for displaying happiness meter
    [SerializeField] private TMP_Text dialogueText; // reference to UI TMP text box for displaying character dialogue
    [SerializeField] private Image characterImage; // reference to UI Image for displaying which sprite is talking
    [SerializeField] private Slider happySlider;
    [SerializeField] Gradient happyGradient;
    [SerializeField] private Image happyBar;

    [SerializeField] private Slider ballastSlider;
    [SerializeField] Gradient ballastGradient;
    [SerializeField] private Image ballastLineHolder;
    [SerializeField] private Sprite[] ballastLines;

    [SerializeField] private Health playerHealth;   // reference to Player's Health

    // Update is called once per frame
    void FixedUpdate()
    {
        depthText.text = SetDepth();            // Depth display--For now, we're just displaying text, but we'll want to convert some or all of these to meters
        SetBallast();                                         // Ballast display--Having a horizontal meter display it with red in the middle and green on the ends
        SetHappiness();                                    // Happiness display--Having a vertical meter display it with green at the top and yellow in the middle and red at bottom when close to 0
        healthText.text = "Health: " + SetHealth().ToString();
    }

    private void SetHappiness()
    {
        happySlider.value = playerController.GetHappy();
        happyBar.color = happyGradient.Evaluate(happySlider.normalizedValue);
    }

    private void SetBallast()
    {
        string printThis = playerController.GetBallast().ToString();
        Debug.Log(printThis);

        if (playerController.GetBallast() == .5f)
            ballastLineHolder.sprite = ballastLines[0];
        else if (playerController.GetBallast() >= .3f && playerController.GetBallast() < .5f)
            ballastLineHolder.sprite = ballastLines[1];
        else if (playerController.GetBallast() >= .1f && playerController.GetBallast() < .3f)
            ballastLineHolder.sprite = ballastLines[2];
        else if (playerController.GetBallast() > 0f && playerController.GetBallast() < .1f)
            ballastLineHolder.sprite = ballastLines[3];
        else if (playerController.GetBallast() == 0)
            ballastLineHolder.sprite = ballastLines[4];
        else if (playerController.GetBallast() < 0f && playerController.GetBallast() > -.1f)
            ballastLineHolder.sprite = ballastLines[5];
        else if (playerController.GetBallast() <= -.1f && playerController.GetBallast() > -.3f)
            ballastLineHolder.sprite = ballastLines[6];
        else if (playerController.GetBallast() <= -.3f && playerController.GetBallast() > -.5f)
            ballastLineHolder.sprite = ballastLines[7];
        else if (playerController.GetBallast() == -.5f)
            ballastLineHolder.sprite = ballastLines[8];

        //        ballastSlider.value = playerController.GetBallast();
        //        ballastBar.color = ballastGradient.Evaluate(ballastSlider.normalizedValue);
    }

    private int SetHealth()
    {
        return playerHealth.GetCurrentHealth();
    }

    private string SetDepth()
    {
        return "Depth: " + (playerController.GetDepth().ToString("F0"));
    }
}
