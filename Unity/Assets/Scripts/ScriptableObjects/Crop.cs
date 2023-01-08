using UnityEngine;

namespace LD52.ScriptableObjects
{
    [CreateAssetMenu(menuName = "LD52/Crop")]
    public class Crop : ScriptableObject
    {
        public string Name => name;
        
        [SerializeField] private Sprite _sprite;
        public Sprite Sprite => _sprite;
        
        [SerializeField] private float _respawnTime;
        public float RespawnTime => _respawnTime;
    }
}