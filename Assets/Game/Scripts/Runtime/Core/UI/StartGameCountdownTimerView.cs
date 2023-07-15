using TMPro;
using UnityEngine;

public class StartGameCountdownTimerView : BaseWindow
{
    [SerializeField] private TMP_Text _value;

    public void RenderValue(string value) => _value.text = value;
}
