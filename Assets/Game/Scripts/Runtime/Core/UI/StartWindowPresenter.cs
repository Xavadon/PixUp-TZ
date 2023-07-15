using System;
using UnityEngine;

public class StartWindowPresenter
{
    private readonly StartWindowView _view;
    private readonly GameStateResolver _gameStateResolver;

    public StartWindowPresenter(StartWindowView view, GameStateResolver gameStateResolver)
    {
        _view = view;
        _gameStateResolver = gameStateResolver;

        _view.StartGameButtonClicked += OnStartGameButtonClicked;
    }

    private void OnStartGameButtonClicked()
    {
        _view.StartGameButtonClicked -= OnStartGameButtonClicked;

        _view.Hide();
        _gameStateResolver.TapToStartClicked();
    }
}
