using UnityEngine;

public class UIController : MonoBehaviour
{
    public void ToggleWindow(GameObject gameObject)
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