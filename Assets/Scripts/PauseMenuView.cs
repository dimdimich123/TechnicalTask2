using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

/// <summary>
/// Implements data analysis (from models), offers the Presenter for updates, <br/>
/// redirects events from the user to the Presenter;
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public sealed class PauseMenuView : MonoBehaviour
{
    [SerializeField] private Button _buttonPause;
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonSave;
    [SerializeField] private Button _buttonExit;

    [SerializeField] private List<Toggle> _toggles;

    private CanvasGroup _canvasGroup;

    public event Action OnPause;
    public event Action OnPlay;
    public event Action OnExit;
    public event Action<int> OnSave;
    public event Func<int, Type> OnToggleChange;
    public event Func<int> OnLoad;
    public event Action<Type> OnChangeControl;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        int? toggleIndex = OnLoad?.Invoke();
        if(toggleIndex == null)
        {
            _toggles[0].isOn = true;
        }
        else
        {
            _toggles[toggleIndex.Value].isOn = true;
        }        
    }

    private void OnEnable()
    {
        _buttonPause.onClick.AddListener(OnPauseButtonClick);
        _buttonPlay.onClick.AddListener(OnPlayButtonClick);
        _buttonSave.onClick.AddListener(OnSaveButtonClick);
        _buttonExit.onClick.AddListener(OnExitButtonClick);

        foreach(Toggle toggle in _toggles)
        {
            toggle.onValueChanged.AddListener(OnToggleStateChange);
        }

    }

    private void OnPauseButtonClick()
    {
        OnPause?.Invoke();
    }

    private void OnPlayButtonClick()
    {
        OnPlay?.Invoke();
    }

    private void OnSaveButtonClick()
    {
        int toggleIndex = _toggles.FindIndex(x => x.isOn);
        OnSave?.Invoke(toggleIndex);
    }

    private void OnExitButtonClick()
    {
        OnExit?.Invoke();
    }

    private void OnToggleStateChange(bool state)
    {
        if(state)
        {
            int toggleIndex = _toggles.FindIndex(x => x.isOn);
            Type type = OnToggleChange?.Invoke(toggleIndex);
            OnChangeControl?.Invoke(type);
        } 
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnDisable()
    {
        _buttonPause.onClick.RemoveAllListeners();
        _buttonPlay.onClick.RemoveAllListeners();
        _buttonSave.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();

        foreach(Toggle toggle in _toggles)
        {
            toggle.onValueChanged.RemoveAllListeners();
        }
    }
}
