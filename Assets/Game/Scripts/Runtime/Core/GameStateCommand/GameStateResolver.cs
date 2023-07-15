using NaughtyAttributes;
using UnityEngine;

public class GameStateResolver : MonoBehaviour
{
    [SerializeField] private GameStateCommandService _gameStateManager;

    [Button]
    public void StartGame() => _gameStateManager.Invoke<StartGameCommand>();

    [Button]
    public void TapToStartClicked() => _gameStateManager.Invoke<TapToStartCommand>();

    [Button]
    public void WinGame() => _gameStateManager.Invoke(new EndGameCommand { IsVictory = true, Reward = 50 });

    [Button]
    public void LoseGame() => _gameStateManager.Invoke(new EndGameCommand { IsVictory = false, Reward = 5});

    [Button]
    public void PauseGame() => _gameStateManager.Invoke(new PauseGameCommand { IsPaused = true });

    [Button]
    public void ResumeGame() => _gameStateManager.Invoke(new PauseGameCommand { IsPaused = false });

    [Button]
    public void RestartGame() => _gameStateManager.Invoke<RestartGameCommand>();
}