using UnityEngine.SceneManagement;

public class PlayButton : MenuButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}