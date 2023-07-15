public class DefeatWindowPresenter : IGameStateCommandsListener<EndGameCommand>
{
    private readonly DefeatWindowView _view;
    private readonly GameStateResolver _gameStateResolver;

    public DefeatWindowPresenter(DefeatWindowView view, GameStateResolver gameStateResolver)
    {
        _view = view;
        _gameStateResolver = gameStateResolver;
    }

    public void ReactCommand(EndGameCommand command)
    {
        if (command.IsVictory)
            return;

        _view.Show();
        _view.RenderReward(command.Reward.ToString());

        _view.RestartButtonClicked += OnRestartButtonClicked;
    }

    private void OnRestartButtonClicked()
    {
        _view.RestartButtonClicked -= OnRestartButtonClicked;

        _gameStateResolver.RestartGame();
    }
}
