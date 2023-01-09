using System.Collections;
using System.Linq;
using LD52.Enums;
using LD52.Managers;
using UnityEngine;

namespace LD52.Models
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class CropInstance : MonoBehaviour
    {
        [SerializeField] private CropType _cropType;
        public CropType CropType => _cropType;

        private Vector2 _originalPosition;
        private BoxCollider2D _boxCollider2D;
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _dirtSprite;
        private Sprite _originalSprite;
        
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalPosition = transform.position;
            _originalSprite = _spriteRenderer.sprite;
        }

        public void Respawn()
        {
            StartCoroutine(RespawnRoutine());
        }
        
        public IEnumerator RespawnRoutine()
        {
            _boxCollider2D.enabled = false;
            _spriteRenderer.sprite = _dirtSprite;
            transform.position = _originalPosition;
            var crop = MinigameManager.Instance.Crops.First(x => x.CropType == _cropType);
            yield return new WaitForSeconds(crop.RespawnTime);
            _spriteRenderer.sprite = _originalSprite;
            _boxCollider2D.enabled = true;
            AudioManager.Instance.Play("grown");
        }
    }
}