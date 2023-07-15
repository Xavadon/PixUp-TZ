using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindowView : BaseWindow
{
    [SerializeField] private TMP_Text _rewardLabel;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _resumeButton;

    public event Action RestartButtonClicked;
    public event Action ResumeButtonClicked;

    protected override void OnShow()
    {
        _restartGameButton.onClick.AddListener(OnRestartGameButtonClicked);
        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
    }

    protected override void OnHide()
    {
        _restartGameButton.onClick.AddListener(OnRestartGameButtonClicked);
        _resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
    }

    private void OnRestartGameButtonClicked() => RestartButtonClicked?.Invoke();

    private void OnResumeButtonClicked() => ResumeButtonClicked?.Invoke();
}
