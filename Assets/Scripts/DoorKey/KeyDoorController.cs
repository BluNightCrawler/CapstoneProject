using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{

    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        [Header("Animation Names")]
        [SerializeField] private string openAnimationName = "DoorOpen";
        [SerializeField] private string closeAnimationName = "DoorClose";

        [SerializeField] private int timetoShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private KeyInventory _keyInventory = null;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            doorAnim=gameObject.GetComponent<Animator>();
}

        private IEnumerator pauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }
        public void PlayAnimation()
        {
            if (_keyInventory.hasRedKey)
            {
                OpenDoor();
            }
            //KNow I can get other color of Keys Door
            else
            {
                StartCoroutine(showDoorLocked());
            }
        }
        void OpenDoor()
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(pauseDoorInteraction());

            }
            else if (doorOpen && !pauseInteraction)
            {
                doorAnim.Play(closeAnimationName, 0, 0.0f);
                doorOpen = false;
                StartCoroutine(pauseDoorInteraction());
            }
        }
        IEnumerator showDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timetoShowUI);
            showDoorLockedUI.SetActive(false);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}