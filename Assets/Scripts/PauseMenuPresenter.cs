using UnityEngine;


/// <summary>
/// Implements the interaction between Model and View of the pause menu. <br/>
/// Binds the actions contained in the View class to the methods of the Model class.
/// </summary>
[RequireComponent(typeof(PauseMenuView))]
public sealed class PauseMenuPresenter : MonoBehaviour
{
    private PauseMenuView _view;
    private PauseMenuModel _model;

    private void Awake()
    {
        _view = GetComponent<PauseMenuView>();
        _model = new PauseMenuModel();
    }

    private void OnEnable()
    {
        _view.OnPause += OnPause;
        _view.OnPlay += OnPlay;
        _view.OnSave += OnSave;
        _view.OnExit += OnExit;
        _view.OnToggleChange += OnToggleChange;
        _view.OnLoad += OnLoad;
    }

    public void OnPause()
    {
        _model.ChangeTimeScale();
        _view.Open();
    }

    public void OnPlay()
    {
        _model.ChangeTimeScale();
        _view.Close();
    }

    public void OnSave(int toggleIndex)
    {
        _model.SaveOptions(toggleIndex);
    }

    private void OnExit()
    {
        _model.ExitGame();
    }

    private System.Type OnToggleChange(int toggleIndex)
    {
        return _model.IndexToControl(toggleIndex);
    }

    private int OnLoad()
    {
        return _model.LoadOptions();
    }

    private void OnDisable()
    {
        _view.OnPause -= OnPause;
        _view.OnPlay -= OnPlay;
        _view.OnSave -= OnSave;
        _view.OnExit -= OnExit;
        _view.OnToggleChange -= OnToggleChange;
        _view.OnLoad -= OnLoad;
    }
}
