using LD52.Models;
using UnityEngine;

namespace LD52.Minigame
{
    public class Basket : MonoBehaviour
    {
        public BasketSet Set { get; set; }

        public void Generate()
        {
            Set = new BasketSet
            {
                Crop1 = new Crop()
            };
        }
    }
}