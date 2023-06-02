using UnityEngine;


namespace Banana.UI
{
    public class UIManager : MonoBehaviour
    {
        private MenuPanel _menuPanel;
        private GamePanel _gamePanel;
        private WinPanel _winPanel;
        private FailPanel _failPanel;

        private void Awake()
        {
            _menuPanel = GetComponentInChildren<MenuPanel>(true);
            _gamePanel = GetComponentInChildren<GamePanel>(true);
            _failPanel = GetComponentInChildren<FailPanel>(true);
            _winPanel = GetComponentInChildren<WinPanel>(true);
        }

        private void Start()
        {
            ChangePanel(TypePanel.Menu);
            _menuPanel.StartedGame += StartGame;
            Spawner.Spawner.Instance.AllEnemyRip += OnWin;

        }
        
        private void OnDestroy()
        {
            _menuPanel.StartedGame -= StartGame;
            Spawner.Spawner.Instance.AllEnemyRip -= OnWin;
        }
        
        private void OnWin()
        {
            ChangePanel(TypePanel.Win);
        }

        private void StartGame()
        {
            ChangePanel(TypePanel.Game);
        }

        private void ChangePanel(TypePanel typePanel)
        {
            _failPanel.gameObject.SetActive(TypePanel.Fail == typePanel);
            _menuPanel.gameObject.SetActive(TypePanel.Menu == typePanel);
            _gamePanel.gameObject.SetActive(TypePanel.Game == typePanel);
            _winPanel.gameObject.SetActive(TypePanel.Win == typePanel);
        }
    }
}