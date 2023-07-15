using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateCommandService : MonoBehaviour
{
    private Dictionary<Type, List<object>> _listenersMap = new();

    public void AddListener<TCommand>(IGameStateCommandsListener<TCommand> listener)
        where TCommand : struct, IGameStateCommand
    {
        var commandType = typeof(TCommand);

        if (!_listenersMap.ContainsKey(commandType))
            _listenersMap[commandType] = new List<object>();

        _listenersMap[commandType].Add(listener);
    }

    public void RemoveListener<TCommand>(IGameStateCommandsListener<TCommand> listener)
        where TCommand : struct, IGameStateCommand
    {
        var commandType = typeof(TCommand);

        if (_listenersMap.ContainsKey(commandType))
        {
            var listeners = _listenersMap[commandType];
            listeners.Remove(listener as IGameStateCommandsListener<IGameStateCommand>);

            if (listeners.Count == 0)
                _listenersMap.Remove(commandType);
        }
    }

    public void Invoke<TCommand>(TCommand gameStateCommand = default)
        where TCommand : struct, IGameStateCommand
    {
        var commandType = typeof(TCommand);

        if (_listenersMap.TryGetValue(commandType, out var listeners))
        {
            foreach (var listener in listeners)
                (listener as IGameStateCommandsListener<TCommand>).ReactCommand(gameStateCommand);
        }
    }
}