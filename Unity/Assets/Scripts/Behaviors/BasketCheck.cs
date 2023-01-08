using System;
using System.Collections;
using UnityEngine;

namespace LD52
{
    public class BasketCheck : MonoBehaviour
    {
        private int currentNumberOfItems;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            currentNumberOfItems += 1;
        }

        private void OnTriggerExit2D()
        {
            currentNumberOfItems -= 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (currentNumberOfItems == 3)
            {
                Debug.Log("3 items");
            }
        }
    }
}
