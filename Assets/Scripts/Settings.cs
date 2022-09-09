using System;

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
