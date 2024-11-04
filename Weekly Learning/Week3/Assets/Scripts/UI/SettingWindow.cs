using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingWindow : MonoBehaviour, IUIWindow
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleWindow()
    {
        gameObject.SetActive(!IsOpen(gameObject));
        ToggleCursor();
    }

    private bool IsOpen(GameObject gameObject)
    {
        return gameObject.activeInHierarchy;
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        CharacterManager.Instance.Player.controller.canLook = !toggle;
    }
}
