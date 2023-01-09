using LD52.Minigame;
using UnityEngine;

namespace LD52
{
    public class BasketCheck : MonoBehaviour
    {
        [SerializeField] private Basket _basket;
        public Basket Basket => _basket;
    }
}
