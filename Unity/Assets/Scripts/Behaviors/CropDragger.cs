using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD52
{
    public class CropDragger : MonoBehaviour
    {
        private bool isDragging;
        private Vector2 initialPosition;

        public void OnMouseDown()
        {
            isDragging = true;
            initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }

        public void OnMouseUp()
        {
            isDragging = false;
            transform.Translate(initialPosition);
        }

        // Update is called once per frame
        void Update()
        {
            if (isDragging)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
            }
        
        }
    }
}
