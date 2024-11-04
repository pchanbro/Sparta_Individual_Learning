using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIWindow
{
    public void ToggleWindow();
}

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    { get
        {
            if (instance == null)
            {
                instance = new GameObject("UIManager").AddComponent<UIManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    private SettingWindow settingWindow;
    public SettingWindow SettingWindow { get { return settingWindow; } }

    [SerializeField]
    private UICondition uiCondition;
    public UICondition UICondition { get { return uiCondition; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
