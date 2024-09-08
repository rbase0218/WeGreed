using UnityEngine;
using DG.Tweening;

public enum SceneName
{
    Title,
    Game
}

public class App : Singleton<App>
{
    private ViewManager _view;
    private UIManager _ui;

    private TitleData _titleData;

    #region Getter Setter
    public partial class Manager
    {
        public static ViewManager View => Instance._view;
        public static UIManager UI => Instance._ui;
    }

    public partial class Data
    {
        public static TitleData Title = Instance._titleData;
    }
    #endregion

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 120;

        DOTween.safeModeLogBehaviour = DG.Tweening.Core.Enums.SafeModeLogBehaviour.Error;

        DontDestroyOnLoad(gameObject);
    }

    public static void LoadScene(SceneName sceneName)
    {
        DOTween.KillAll();

        UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneName);
    }

    #region Get View As T
    public static T ViewManagerAs<T>(object manager) where T : MonoBehaviour
    {
        if (manager == null || manager is not T)
        {
            return null;
        }

        return manager as T;
    }

    public static T GetViewAs<T>() where T : MonoBehaviour
    {
        return ViewManagerAs<T>(Manager.View);
    }

    public static T GetUIAs<T>() where T : MonoBehaviour
    {
        return ViewManagerAs<T>(Manager.UI);
    }
    #endregion

    #region  Get ViewManager
    //public static TitleManager GetTitleManager()
    //{
    //    return GetViewAs<TitleManager>();
    //}

    public partial class Manager
    {
        //public static TitleManager Title { get => GetTitleManager(); }
    }
    #endregion

    #region  Get UIManager
    //public static TitleUIManager GetTitleUIManager()
    //{
    //    return GetUIAs<TitleUIManager>();
    //}

    public class UI
    {
        //public static TitleUIManager Title { get => GetTitleUIManager(); }
    }
    #endregion
}