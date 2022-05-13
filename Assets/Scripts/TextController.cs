using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.SceneManagement;
using Rewired;

public class TextController : MonoBehaviour
{

    // Rewired assets
    [SerializeField] private int playerID = 0;
    [SerializeField] private Player player;

    // Ink assets
    [SerializeField] private TextAsset inkJsonFile;
    private Story inkScript;

    // GameObjects for the Text Box
    public GameObject textBox;
    public TMP_Text dialogueBox;
    public TMP_Text nameTag;

    // List for the tags in the ink file
    List<string> tags;

    // Sprite Array for Narrative Section
    [SerializeField] private Sprite[] charSprites;
    // Sprite Renderer for the narrative section Character Sprites
    [SerializeField] private Image charSpriteRenderer;

    // Scene to Load after script plays
    [SerializeField] private int sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        LoadScript();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Interact"))
        {
            DisplayNextLine();
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

    public void LoadScript()
    {
        // Enable the dialogue box
        Show();
        // Load the json file
        inkScript = new Story(inkJsonFile.text);
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
            SceneManager.LoadScene(sceneToLoad);

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
                    ChangeName(param);
                    break;
                case "sprite":
                    ChangeCharSprite(param);
                    break;
                case "music":
                    break;
            }
        }
    }

    private void ChangeName(string name)
    {
        string speakerName;

        speakerName = name;

        nameTag.text = speakerName;
    }

    private void ChangeCharSprite(string bg)
    {
        Sprite charSprite = null;

        switch (bg.ToLower())
        {
            case "cap_mad":
                charSprite = charSprites[0];
                break;
            case "cap_neutral":
                charSprite = charSprites[1];
                break;
            case "cap_happy":
                charSprite = charSprites[2];
                break;
            case "rob_mad":
                charSprite = charSprites[3];
                break;
            case "rob_neutral":
                charSprite = charSprites[4];
                break;
            case "rob_happy":
                charSprite = charSprites[5];
                break;
            case "eng_mad":
                charSprite = charSprites[6];
                break;
            case "eng_neutral":
                charSprite = charSprites[7];
                break;
            case "eng_happy":
                charSprite = charSprites[8];
                break;
            case "sai_mad":
                charSprite = charSprites[9];
                break;
            case "sai_neutral":
                charSprite = charSprites[10];
                break;
            case "sai_happy":
                charSprite = charSprites[11];
                break;
        }

        charSpriteRenderer.sprite = charSprite;
    }
}
