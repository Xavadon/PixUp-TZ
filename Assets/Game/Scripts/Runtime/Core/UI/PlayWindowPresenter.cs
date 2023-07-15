public class PlayWindowPresenter : IGameStateCommandsListener<StartGameCommand>, IGameStateCommandsListener<EndGameCommand>
{
    private readonly PlayWindowView _view;
    private readonly GameStateResolver _gameStateResolver;

    public PlayWindowPresenter(PlayWindowView view, GameStateResolver gameStateResolver)
    {
        _view = view;
        _gameStateResolver = gameStateResolver;
    }

    public void ReactCommand(StartGameCommand command)
    {
        _view.Show();

        _view.PauseButtonClicked += OnPauseButtonClicked;
    }

    public void ReactCommand(EndGameCommand command)
    {
        _view.PauseButtonClicked -= OnPauseButtonClicked;

        _view.Hide();
    }

    private void OnPauseButtonClicked() => _gameStateResolver.PauseGame();
}
