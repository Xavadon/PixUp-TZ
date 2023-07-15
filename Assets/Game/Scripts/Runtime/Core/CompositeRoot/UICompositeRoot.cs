using UnityEngine;
using UnityEngine.UI;

public sealed class UICompositeRoot : CompositeRoot
{
    [SerializeField] private GameStateCommandService _gameStateCommandService;
    [SerializeField] private GameStateResolver _gameStateResolver;
    [SerializeField] private CountdownTimer _countdownTimer;
    [SerializeField] private StartGameCountdownTimerView _startTimerView;
    [SerializeField] private VictoryWindowView _victoryView;
    [SerializeField] private DefeatWindowView _defeatView;
    [SerializeField] private PauseWindowView _pauseView;
    [SerializeField] private StartWindowView _startView;
    [SerializeField] private PlayWindowView _playView;

    public override void Compose()
    {
        BindVictory();
        BindDefeat();
        BindPause();
        BindStart();
        BindStartCountdownTimer();
        BindPlay();
    }

    private void BindVictory()
    {
        var presenter = new VictoryWindowPresenter(_victoryView, _gameStateResolver);
        _gameStateCommandService.AddListener<EndGameCommand>(presenter);
    }

    private void BindDefeat()
    {
        var presenter = new DefeatWindowPresenter(_defeatView, _gameStateResolver);
        _gameStateCommandService.AddListener<EndGameCommand>(presenter);
    }

    private void BindPause()
    {
        var presenter = new PauseWindowPresenter(_pauseView, _gameStateResolver);
        _gameStateCommandService.AddListener<PauseGameCommand>(presenter);
    }

    private void BindStart()
    {
        var presenter = new StartWindowPresenter(_startView, _gameStateResolver);
    }

    private void BindStartCountdownTimer()
    {
        var presenter = new StartGameCountdownTimerPresenter(_startTimerView, _countdownTimer, _gameStateResolver);
        _gameStateCommandService.AddListener<TapToStartCommand>(presenter);
    }

    private void BindPlay()
    {
        var presenter = new PlayWindowPresenter(_playView, _gameStateResolver);
        _gameStateCommandService.AddListener<EndGameCommand>(presenter);
        _gameStateCommandService.AddListener<StartGameCommand>(presenter);
    }
}
