using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour, IGameStateCommandsListener<RestartGameCommand>
{
    [SerializeField] private GameStateCommandService _stateCommandService;

    private void Awake()
    {
        _stateCommandService.AddListener<RestartGameCommand>(this);
    }

    public void ReactCommand(RestartGameCommand command) => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
