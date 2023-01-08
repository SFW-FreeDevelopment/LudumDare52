using System;

namespace LD52.Controllers
{
    public static class EventController
    {
        public static event Action OnGameStarted;
        public static void GameStarted() => OnGameStarted?.Invoke();
        
        public static event Action OnGameOver;
        public static void GameOver() => OnGameOver?.Invoke();

        public static event Action OnBasketCollected;
        public static void BasketCollected() => OnBasketCollected?.Invoke();
    }
}