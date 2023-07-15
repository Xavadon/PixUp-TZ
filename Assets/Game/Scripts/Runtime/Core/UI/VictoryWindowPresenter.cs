using System;

public class VictoryWindowPresenter : IGameStateCommandsListener<EndGameCommand>
{
    private readonly VictoryWindowView _view;
    private readonly GameStateResolver _gameStateResolver;

    public VictoryWindowPresenter(VictoryWindowView view, GameStateResolver gameStateResolver)
    {
        _view = view;
        _gameStateResolver = gameStateResolver;
    }

    public void ReactCommand(EndGameCommand command)
    {
        if (!command.IsVictory)
            return;

        _view.Show();
        _view.RenderReward(command.Reward.ToString());

        _view.RestartButtonClicked += OnRestartGameButtonClicked;
    }

    private void OnRestartGameButtonClicked()
    {
        _view.RestartButtonClicked -= OnRestartGameButtonClicked;

        _gameStateResolver.RestartGame();
    }
}
