using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefeatWindowView : BaseWindow
{
    [SerializeField] private TMP_Text _rewardLabel;
    [SerializeField] private Button _restartGameButton;

    public event Action RestartButtonClicked;

    protected override void OnShow()
    {
        _restartGameButton.onClick.AddListener(OnRestartGameButtonClicked);
    }

    protected override void OnHide()
    {
        _restartGameButton.onClick.AddListener(OnRestartGameButtonClicked);
    }

    public void RenderReward(string reward) => _rewardLabel.text = reward;

    private void OnRestartGameButtonClicked() => RestartButtonClicked?.Invoke();
}
