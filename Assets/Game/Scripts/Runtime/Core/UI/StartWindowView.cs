using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartWindowView : BaseWindow
{
    [SerializeField] private Button _startGameButton;

    public event Action StartGameButtonClicked;

    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
    }

    private void OnDisable()
    {
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
    }

    private void OnStartGameButtonClicked()
    {
        StartGameButtonClicked?.Invoke();
    }
}

