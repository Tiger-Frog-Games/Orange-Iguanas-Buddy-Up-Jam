using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OrangeIguanas
{
    public class PlayerDetector : MonoBehaviour
    {
        #region Variables

        [SerializeField] private bool CanOnlyDetectOnce = false;
        [SerializeField] private BoxCollider2D triggerZone;
        [SerializeField] private UnityEvent OnPlayerDetected;
        [SerializeField] private UnityEvent OnPlayerLostDetected;

        private bool isTriggered = false;

        #endregion

        #region Unity Methods

        private void OnTriggerEnter2D(Collider2D collision)
        {
           
            if (isTriggered == false || (CanOnlyDetectOnce == false && isTriggered == true))
            {
                OnPlayerDetected.Invoke();
                //Just means that the player is currently in the zone. This is used for when the player enters the zone the 2nd time
                print("Test");
                isTriggered = false;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(isTriggered == false)
            {
                OnPlayerLostDetected.Invoke();
                isTriggered = true;
            }
        }

        #endregion

        #region Methods



        #endregion
    }
}