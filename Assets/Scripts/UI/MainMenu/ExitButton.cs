using UnityEngine;

public class ExitButton : MenuButton
{
    protected override void OnClick()
    {
        Application.Quit();
    }
}