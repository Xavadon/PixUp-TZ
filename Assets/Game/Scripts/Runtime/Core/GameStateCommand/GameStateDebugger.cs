using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateDebugger : MonoBehaviour,
    IGameStateCommandsListener<RestartGameCommand>,
    IGameStateCommandsListener<TapToStartCommand>,
    IGameStateCommandsListener<StartGameCommand>,
    IGameStateCommandsListener<EndGameCommand>,
    IGameStateCommandsListener<PauseGameCommand>
{
    [SerializeField] private GameStateCommandService _stateCommandService;

    private void Awake()
    {
        _stateCommandService.AddListener<RestartGameCommand>(this);
        _stateCommandService.AddListener<TapToStartCommand>(this);
        _stateCommandService.AddListener<StartGameCommand>(this);
        _stateCommandService.AddListener<EndGameCommand>(this);
        _stateCommandService.AddListener<PauseGameCommand>(this);
    }

    public void ReactCommand(RestartGameCommand command) =>  Debug.Log("TapToStartCommand");

    public void ReactCommand(TapToStartCommand command) => Debug.Log("TapToStartCommand");

    public void ReactCommand(StartGameCommand command) => Debug.Log("StartGameCommand");

    public void ReactCommand(EndGameCommand command) => Debug.Log($"EndGameCommand IsVictory : {command.IsVictory}");

    public void ReactCommand(PauseGameCommand command) => Debug.Log($"Is Pause {command.IsPaused}");
}
