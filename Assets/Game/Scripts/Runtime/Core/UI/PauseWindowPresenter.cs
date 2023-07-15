public class PauseWindowPresenter : IGameStateCommandsListener<PauseGameCommand>
{
    private readonly PauseWindowView _view;
    private readonly GameStateResolver _gameStateResolver;

    public PauseWindowPresenter(PauseWindowView view, GameStateResolver gameStateResolver)
    {
        _view = view;
        _gameStateResolver = gameStateResolver;
    }

    public void ReactCommand(PauseGameCommand command)
    {
        if (command.IsPaused)
        {
            _view.Show();
            _view.RestartButtonClicked += OnRestartButtonClicked;
            _view.ResumeButtonClicked += OnResumeButtonClicked;
        }
        else
        {
            _view.Hide();
            _view.RestartButtonClicked -= OnRestartButtonClicked;
            _view.ResumeButtonClicked -= OnResumeButtonClicked;
        }
    }

    private void OnResumeButtonClicked() => _gameStateResolver.ResumeGame();

    private void OnRestartButtonClicked()
    {
        _view.RestartButtonClicked -= OnRestartButtonClicked;
        _view.ResumeButtonClicked -= OnResumeButtonClicked;

        _gameStateResolver.RestartGame();
    }
}
