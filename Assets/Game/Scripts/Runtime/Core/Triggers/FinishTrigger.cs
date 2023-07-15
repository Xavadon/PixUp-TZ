using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameStateResolver _gameStateResolver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerTag>(out var player))
            _gameStateResolver.WinGame();
    }
}
