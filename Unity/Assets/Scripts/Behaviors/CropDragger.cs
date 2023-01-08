using LD52.Managers;
using UnityEngine;

namespace LD52
{
    public class CropDragger : MonoBehaviour
    {
        private bool isDragging;
        private bool isInBasket;
        private Vector2 initialPosition = new Vector2(0f, 0f);

        public void OnMouseDown()
        {
            AudioManager.Instance.Play("carrotpull");
            isDragging = true;
            initialPosition = transform.position;
        }

        public void OnMouseUp()
        {
            AudioManager.Instance.Play("placeinbasket");
            isDragging = false;
            if (!isInBasket)
            {
                transform.position = initialPosition;
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Basket"))
            {
                isInBasket = true;
            }
        }

        private void OnTriggerExit2D()
        {
            isInBasket = false;
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
