using System;

/// <summary>
/// Stores data about the selected control type.
/// </summary>
[Serializable]
public class Settings
{
    public const string Path = "/data/Settings.dat";
    private int _controlIndex;

    public int ControlIndex => _controlIndex;

    public Settings(int controlIndex) => _controlIndex = controlIndex;

    public Settings()
    {
        _controlIndex = 0;
    }
}
