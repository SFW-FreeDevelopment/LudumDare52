using LD52.Managers;
using LD52.Minigame;
using LD52.Models;
using UnityEngine;

namespace LD52
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(CropInstance))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class CropDragger : MonoBehaviour
    {
        private bool isDragging;
        private bool isInBasket;
        private Vector2 initialPosition = new Vector2(0f, 0f);
        private Basket _basket;
        
        private BoxCollider2D _boxCollider2D;
        private CropInstance _cropInstance;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _cropInstance = GetComponent<CropInstance>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

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
            else
            {
                if (_basket.CheckIncomingCrop(_cropInstance.CropType))
                {
                    _cropInstance.Respawn();
                }
                else
                {
                    transform.position = initialPosition;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Basket"))
            {
                isInBasket = true;
                _basket = other.gameObject.GetComponent<BasketCheck>().Basket;
            }
        }

        private void OnTriggerExit2D()
        {
            isInBasket = false;
            _basket = null;
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
