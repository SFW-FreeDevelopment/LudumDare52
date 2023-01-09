using LD52.Enums;
using UnityEngine;

namespace LD52.Models
{
    public class CropInstance : MonoBehaviour
    {
        [SerializeField] private CropType _cropType;
        public CropType CropType => _cropType;
    }
}