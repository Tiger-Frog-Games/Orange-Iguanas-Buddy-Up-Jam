using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private GameObject audioControllerObject;
    private AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        audioControllerObject = GameObject.FindWithTag("AudioController");
        audioController = audioControllerObject.GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioController.Upgrade();
            if (playerController.GetHasTorpedo() == false)
                playerController.SetTorpedo();
            else if (playerController.GetHasTorpedo() == true && playerController.GetHasExtraHealth() == false)
                playerController.SetHasExtraHealth();
            else if (playerController.GetHasTorpedo() == true && playerController.GetHasExtraHealth() == true && playerController.GetHasBomb() == false)
                playerController.SetBomb();
            Destroy(gameObject);
            audioController.Upgrade();
        }

    }

    /*
    private void RandomUpgrade()
    {
        
    }
    */
}
