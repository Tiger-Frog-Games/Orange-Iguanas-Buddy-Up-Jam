using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    [SerializeField] private TMP_Text depthText;
    [SerializeField] private TMP_Text ballastText;


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        depthText.text = "Depth: " + playerController.GetDepth().ToString("F3");
        ballastText.text = "Ballast: " + playerController.GetBallast().ToString("F1");
    }
}
