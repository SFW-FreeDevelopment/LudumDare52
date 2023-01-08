﻿using LD52.Enums;
using LD52.Managers;
using LD52.ScriptableObjects;
using UnityEngine;

namespace LD52.Minigame
{
    public class Basket : MonoBehaviour
    {
        [Header("Sprites")]
        [SerializeField] private Sprite _checkmarkSprite;
        
        [Header("Sprite Renderers")]
        [SerializeField] private SpriteRenderer _leftCropSpriteRenderer;
        [SerializeField] private SpriteRenderer _centerCropSpriteRenderer;
        [SerializeField] private SpriteRenderer _RightCropSpriteRenderer;

        private (Crop Crop, bool Filled) _leftCrop, _centerCrop, _rightCrop;

        public void Generate()
        {
            var crops = MinigameManager.Instance.Crops;
            
            _leftCrop = (crops[Random.Range(0, crops.Length)], false);
            _centerCrop = (crops[Random.Range(0, crops.Length)], false);
            _rightCrop = (crops[Random.Range(0, crops.Length)], false);

            _leftCropSpriteRenderer.sprite = _leftCrop.Crop.Sprite;
            _centerCropSpriteRenderer.sprite = _centerCrop.Crop.Sprite;
            _RightCropSpriteRenderer.sprite = _rightCrop.Crop.Sprite;
        }

        public bool CheckIncomingCrop(CropType cropType)
        {
            if (!_leftCrop.Filled && _leftCrop.Crop.CropType == cropType)
            {
                _leftCrop.Filled = true;
                _leftCropSpriteRenderer.sprite = _checkmarkSprite;
            }
            else if (!_centerCrop.Filled && _centerCrop.Crop.CropType == cropType)
            {
                _centerCrop.Filled = true;
                _centerCropSpriteRenderer.sprite = _checkmarkSprite;
            }
            else if (!_rightCrop.Filled && _rightCrop.Crop.CropType == cropType)
            {
                _rightCrop.Filled = true;
                _RightCropSpriteRenderer.sprite = _checkmarkSprite;
            }
            else
            {
                return false;
            }

            if (_leftCrop.Filled && _centerCrop.Filled && _rightCrop.Filled)
            {
                // TODO: Play basket complete sound
                // TODO: Basket complete things
            }
            
            return true;
        }
    }
}