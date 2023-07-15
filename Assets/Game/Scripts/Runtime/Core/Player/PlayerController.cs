using UnityEngine;

public class PlayerController : IUpdatable, 
    IGameStateCommandsListener<PauseGameCommand>,
    IGameStateCommandsListener<EndGameCommand>,
    IGameStateCommandsListener<StartGameCommand>
{
    private readonly IInputService _inputService;
    private readonly LaneMovement _movement;

    private bool _canControll;

    public PlayerController(IInputService inputService, LaneMovement playerMovement)
    {
        _inputService = inputService;
        _movement = playerMovement;
    }

    public void Tick(float tick)
    {
        if (!_canControll)
            return;

        if (_inputService.LeftArrowKeyDown)
            _movement.MoveLeft();
        else if (_inputService.RightArrowKeyDown)
            _movement.MoveRight();

        _movement.MoveForward();
    }

    public void ReactCommand(PauseGameCommand command) => _canControll = !command.IsPaused;

    public void ReactCommand(EndGameCommand command) => _canControll = false;

    public void ReactCommand(StartGameCommand command) => _canControll = true;
}
