public class StartGameCountdownTimerPresenter : IGameStateCommandsListener<TapToStartCommand>
{
    private const int CountdownTime = 3;

    private readonly CountdownTimer _timer;
    private readonly StartGameCountdownTimerView _view;
    private readonly GameStateResolver _gameStateResolver;

    public StartGameCountdownTimerPresenter(StartGameCountdownTimerView view, CountdownTimer timer, GameStateResolver gameStateResolver)
    {
        _timer = timer;
        _view = view;
        _gameStateResolver = gameStateResolver;
    }

    public void ReactCommand(TapToStartCommand command)
    {
        _view.Show();
        _timer.StartCountdown(CountdownTime);

        _timer.Ticked += OnTimerTicked;
        _timer.Completed += OnTimerCompleted;
    }

    private void OnTimerCompleted()
    {
        _timer.Ticked -= OnTimerTicked;
        _timer.Completed -= OnTimerCompleted;

        _view.Hide();

        _gameStateResolver.StartGame();
    }

    private void OnTimerTicked(int timeLeft)
    {
        _view.RenderValue(timeLeft.ToString());
    }
}
