using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Пожелаю удачи в чтении этого кода :))
// Многие моменты значительно упрощены.
// Экспериментальная работа с GameStateCommandService, на практике получилось удобно, служит только для глобальных игровых событий.

public class GameRoot : MonoBehaviour
{
    [SerializeField] private CompositeRoot[] _compositeRootOrder;

    private List<IUpdatable> _updatables = new();

    private void Awake()
    {
        foreach (var composite in _compositeRootOrder)
        {
            composite.Compose();

            if (composite is IUpdatable updatable)
                _updatables.Add(updatable);
        }
    }

    private void Update()
    {
        var tick = Time.deltaTime;

        for (int i = 0; i < _updatables.Count; i++)
            _updatables[i].Tick(tick);
    }
}