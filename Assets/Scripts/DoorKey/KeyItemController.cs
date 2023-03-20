using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool redKey = false;
        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObject;

        private void Start()
        {
            if (redDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
        }
        public void ObjectInteraction()
        {
            if (redDoor)
            {
                doorObject.transform.Translate(Vector3.up * Time.deltaTime * 5);
                //if bool is true opens door
            }
            else if (redKey)
            {
                _keyInventory.hasRedKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
