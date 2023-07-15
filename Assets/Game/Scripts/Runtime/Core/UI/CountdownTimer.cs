using System;
using System.Collections;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private int _timeLeft;
    private Coroutine _countingdown;

    public event Action<int> Ticked;
    public event Action Completed;

    public void StartCountdown(int totalTime)
    {
        StopCountdown();

        _countingdown = StartCoroutine(Countingdown(totalTime));
    }

    public void StopCountdown()
    {
        if (_countingdown != null)
        {
            StopCoroutine(_countingdown);
            _countingdown = null;
        }
    }

    private IEnumerator Countingdown(int totalTime)
    {
        var second = new WaitForSeconds(1f);
        _timeLeft = totalTime;

        while (_timeLeft > 0)
        {
            Ticked?.Invoke(_timeLeft);
            _timeLeft--;
            yield return second;
        }

        Completed?.Invoke();
    }
}