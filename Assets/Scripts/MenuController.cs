using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    private List<Toggle> _toggles;
    public event Action<Type> OnToggleChange;

    private void Start()
    {
        Settings settings = DataSerializer.DeserializeData<Settings>(Settings.Path);
        _toggles = GetComponentsInChildren<Toggle>(true).ToList();
        _toggles[settings.ControlIndex].isOn = true;
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void SaveOptions()
    {
        int index = _toggles.FindIndex(x => x.isOn);
        Settings settings = new Settings(index);
        DataSerializer.SerializeData(settings, Settings.Path);
    }

    public void ChangeTimeScale()
    {
        Time.timeScale = 1 - Time.timeScale;
    }

    public void SwipeToggle(bool state)
    {
        if (state)
            OnToggleChange?.Invoke(typeof(Swipe));
    }

    public void DragToggle(bool state)
    {
        if (state)
            OnToggleChange?.Invoke(typeof(Drag));
    }

    public void KeyboardToggle(bool state)
    {
        if (state)
            OnToggleChange?.Invoke(typeof(Keyboard));
    }

    private void Awake()
    {
        if (System.IO.Directory.Exists(Application.persistentDataPath + "/data") == false)
        {
            System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
    }
}
