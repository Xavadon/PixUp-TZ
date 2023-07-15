using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayWindowView : BaseWindow
{
    [SerializeField] private Button _resumeButton;

    public event Action PauseButtonClicked;

    protected override void OnShow()
    {
        _resumeButton.onClick.AddListener(PauseGameButtonClicked);
    }

    protected override void OnHide()
    {
        _resumeButton.onClick.AddListener(PauseGameButtonClicked);
    }

    private void PauseGameButtonClicked() => PauseButtonClicked?.Invoke();
}
