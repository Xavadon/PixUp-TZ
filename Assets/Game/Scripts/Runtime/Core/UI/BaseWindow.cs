using UnityEngine;

public abstract class BaseWindow : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Show()
    {
        _canvasGroup.Show();
        OnShow();
    }

    public void Hide()
    {
        _canvasGroup.Hide();
        OnHide();
    }

    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
