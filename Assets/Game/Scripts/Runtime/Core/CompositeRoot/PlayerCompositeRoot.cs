using UnityEngine;

public sealed class PlayerCompositeRoot : CompositeRoot, IUpdatable
{
    [SerializeField] private GameStateCommandService _gameStateCommandService;
    [SerializeField] private LaneMovement _playerMovement;

    private PlayerController _playerController;

    public override void Compose()
    {
        var input = new DesktopInputService();
        _playerController = new PlayerController(input, _playerMovement);

        _gameStateCommandService.AddListener<StartGameCommand>(_playerController);
        _gameStateCommandService.AddListener<PauseGameCommand>(_playerController);
        _gameStateCommandService.AddListener<EndGameCommand>(_playerController);
    }

    public void Tick(float tick)
    {
        _playerController.Tick(tick);
    }
}

