using UnityEngine;

public class DesktopInputService : IInputService
{
    public bool LeftArrowKeyDown => Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
    public bool RightArrowKeyDown => Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
}
