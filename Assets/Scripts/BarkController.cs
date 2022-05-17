using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using Rewired;

public class BarkController : MonoBehaviour
{
    // Rewired assets
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player player;

    [SerializeField] private PlayerController playerController;  // reference to PlayerController script to get various player components like depth, ballast, happyMeter, etc.
    private int partyLevel;
    private string currentSprite = "cap";

    private float timer = 0f;

    // Ink assets
    [SerializeField] private TextAsset[] inkJsonFiles;
    private Story inkScript;

    // GameObjects for the Text Box

    public TMP_Text dialogueBox;

    // List for the tags in the ink file
    List<string> tags;

    // Sprite Array for Narrative Section
    [SerializeField] private Sprite[] charSprites;
    // Sprite Renderer for the narrative section Character Sprites
    [SerializeField] private Image charSpriteRenderer;

    private bool playedBark1 = false;
    private bool playedBark2 = false;
    private bool playedBark3 = false;
    private bool playedBark4 = false;
    private bool playedBark5 = false;
    private bool playedBark6 = false;
    private bool playedBark7 = false;
    private bool playedBark8 = false;
    private bool playedBark9 = false;
    private bool playedBark10 = false;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        LoadScript(0);
    }

    // Update is called once per frame
    void Update()
    {
       partyLevel = playerController.GetHappy();
        timer += Time.deltaTime;

        if ((playerController.GetDepth() < -10 || timer >= 10f) && playedBark1 == false)
        {
            LoadScript(1);
            playedBark1 = true;
        }

        if ((playerController.GetDepth() < -25 || timer >= 20f) && playedBark2 == false)
        {
            LoadScript(2);
            playedBark2 = true;
        }

        if ((playerController.GetDepth() < -40 || timer >= 30f) && playedBark3 == false)
        {
            LoadScript(3);
            playedBark3 = true;
        }
        
        if (playerController.GetDepth() < -84 && playedBark4 == false)
        {
            LoadScript(4);
            playedBark4 = true;
        }
        if (partyLevel == 0 && timer >= 100f && playedBark5 == false)
        {
            LoadScript(5);
            playedBark5 = true;
        }
        
        if (playerController.GetHasTorpedo() && playedBark6 == false)
        {
            LoadScript(6);
            playedBark6 = true;
        }

        if (playerController.GetHasExtraHealth() && playedBark7 == false)
        {
            LoadScript(7);
            playedBark7 = true;
        }

        if (playerController.GetHasBomb() && playedBark8 == false)
        {
            LoadScript(8);
            playedBark8 = true;
        }


        if ((playerController.GetDepth() < -900) && playedBark9 == false)
        {
            LoadScript(9);
            playedBark9 = true;
        }

        if (currentSprite == "cap")
        {
            if (partyLevel == 0)
            {
                charSpriteRenderer.sprite = charSprites[0];
            }
            else if (partyLevel <= 5)
            {
                charSpriteRenderer.sprite = charSprites[1];
            }
            else
            {
                charSpriteRenderer.sprite = charSprites[2];
            }
        }
        else if (currentSprite == "rob")
        {
            if (partyLevel == 0)
            {
                charSpriteRenderer.sprite = charSprites[3];
            }
            else if (partyLevel <= 5)
            {
                charSpriteRenderer.sprite = charSprites[4];
            }
            else
            {
                charSpriteRenderer.sprite = charSprites[5];
            }

        }
        else if (currentSprite == "sai")
        {
            if (partyLevel == 0)
            {
                charSpriteRenderer.sprite = charSprites[6];
            }
            else if (partyLevel <= 5)
            {
                charSpriteRenderer.sprite = charSprites[7];
            }
            else
            {
                charSpriteRenderer.sprite = charSprites[8];
            }
        }
        else if (currentSprite == "eng")
        {
            if (partyLevel == 0)
            {
                charSpriteRenderer.sprite = charSprites[9];
            }
            else if (partyLevel <= 5)
            {
                charSpriteRenderer.sprite = charSprites[10];
            }
            else
            {
                charSpriteRenderer.sprite = charSprites[11];
            }
        }
        
    }

    // Show the dialogue box if its disabled
    public void Show()
    {
        gameObject.SetActive(true);
    }

    // Hide the dialogue box if its enabled
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void LoadScript(int numToLoad)
    {
        // Load the json file
        inkScript = new Story(inkJsonFiles[numToLoad].text);
        // call the function to display the next line
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        // Checking if there is content to go through
        if (inkScript.canContinue)
        {
            // Gets next line
            string text = inkScript.Continue();
            ParseTags();
            // Removes whitespace from the text
            text = text?.Trim();
            // Displays new text
            dialogueBox.text = text;
        }
        // Display when there is no text.
        else
        {


        }
    }

    // Goes through the Inky script and parses the # tags for
    // backgrounds, sprites, character names
    void ParseTags()
    {
        tags = inkScript.currentTags;

        foreach (string t in tags)
        {
            string prefix = t.Split('.')[0];
            string param = t.Split('.')[1];

            switch (prefix.ToLower())
            {
                case "charname":
                    break;
                case "sprite":
                    ChangeChar(param);
                    break;
                case "music":
                    break;
            }
            break;
        }
    }



    private void ChangeChar(string charName)
    {
        Sprite charSprite = null;

        switch (charName.ToLower())
        {
            case "cap_mad":
                charSprite = charSprites[0];
                currentSprite = "cap";
                break;
            case "cap_neutral":
                charSprite = charSprites[1];
                currentSprite = "cap";
                break;
            case "cap_happy":
                charSprite = charSprites[2];
                currentSprite = "cap";
                break;
            case "rob_mad":
                charSprite = charSprites[3];
                currentSprite = "rob";
                break;
            case "rob_neutral":
                charSprite = charSprites[4];
                currentSprite = "rob";
                break;
            case "rob_happy":
                charSprite = charSprites[5];
                currentSprite = "rob";
                break;
            case "sai_mad":
                charSprite = charSprites[6];
                currentSprite = "sai";
                break;
            case "sai_neutral":
                charSprite = charSprites[7];
                currentSprite = "sai";
                break;
            case "sai_happy":
                charSprite = charSprites[8];
                currentSprite = "sai";
                break;
            case "eng_mad":
                charSprite = charSprites[9];
                currentSprite = "eng";
                break;
            case "eng_neutral":
                charSprite = charSprites[10];
                currentSprite = "eng";
                break;
            case "eng_happy":
                charSprite = charSprites[11];
                currentSprite = "eng";
                break;
        }

        charSpriteRenderer.sprite = charSprite;
    }
}
