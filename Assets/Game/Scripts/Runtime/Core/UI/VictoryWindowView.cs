using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VictoryWindowView : BaseWindow
{
    [SerializeField] private TMP_Text _rewardLabel;
    [SerializeField] private Button _restartButton;

    public event Action RestartButtonClicked;

    protected override void OnShow()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    protected override void OnHide()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    public void RenderReward(string reward) => _rewardLabel.text = reward;

    private void OnRestartButtonClicked() => RestartButtonClicked?.Invoke();
}
