using System;
using UnityEngine;
using UnityEngine.UI;

namespace Banana.UI
{
    public class MenuPanel : MonoBehaviour
    {
        private Button _startGameButton;

        public event Action StartedGame;

        private void Awake()
        {
            _startGameButton = GetComponentInChildren<Button>();
        }

        private void Start()
        {
            _startGameButton.onClick.AddListener(OnStartGame);
        }

        private void OnStartGame()
        {
            StartedGame?.Invoke();
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveListener(OnStartGame);
        }
    }
}