using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingWindow : MonoBehaviour
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

    public void ToggleShow()
    {
        UIManager.Instance.UiController.ToggleWindow(gameObject);
    }
}
