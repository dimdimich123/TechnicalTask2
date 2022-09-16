using UnityEngine;

public enum ControlTypes : int
{
    Swipe = 0,
    Drag = 1,
    KeyBoard = 2
}

/// <summary>
/// Model that performs the operations necessary for the pause menu to work.
/// </summary>
public sealed class PauseMenuModel
{
    public void ChangeTimeScale()
    {
        Time.timeScale = 1 - Time.timeScale;
    }

    public void SaveOptions(int index)
    {
        Settings settings = new Settings(index);
        DataSerializer.SerializeData(settings, Settings.Path);
    }

    public int LoadOptions()
    {
        Settings settings = DataSerializer.DeserializeData<Settings>(Settings.Path);
        return settings.ControlIndex;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public System.Type IndexToControl(int index)
    {
        switch((ControlTypes)index)
        {
            case ControlTypes.Swipe: return typeof(Swipe);
            case ControlTypes.Drag: return typeof(Drag);
            case ControlTypes.KeyBoard: return typeof(Keyboard);
            default: throw new System.Exception($"Unknown control type / Error in {nameof(PauseMenuModel)} class");
        }
    }
}
