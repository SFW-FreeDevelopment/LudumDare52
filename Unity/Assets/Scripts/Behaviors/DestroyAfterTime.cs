using UnityEngine;

namespace LD52.Behaviors
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] public float _time = 3;
        
        public void Start()
        {
            Destroy(gameObject, _time);
        }
    }
}