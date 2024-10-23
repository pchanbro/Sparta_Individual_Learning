using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction spaceAction;

    void Start()
    {
        // [구현사항 1] actionAsset에서 Space 액션을 찾고 활성화합니다.
        // InputActionAsset에서 "Space"라는 이름의 InputAction을 찾는다.
        // 그러나 이 코드만으로는 InputAction이 활성화 되지 않는다. InputAction을 활성화하려면 Enable 메서드를 호출해야 한다.
        spaceAction = actionAsset.FindAction("Space");
        if (spaceAction != null )
        {
            spaceAction.Enable();
        }
    }

    // [구현사항 2] ContextMenu 어트리뷰트를 활용해서 인스펙터창에서 적용할 수 있도록 함
    [ContextMenu("RebindSpaceToEscape")]
    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;

        // [구현사항 3] 기존 바인딩을 비활성화하고 새 키로 재바인딩
        spaceAction.ApplyBindingOverride("<Keyboard>/Escape");


        Debug.Log("Done!");
    }

    void OnDestroy()
    {
        // 액션을 비활성화합니다.
        spaceAction?.Disable();
    }

    void OnSpace()
    {
        Debug.Log("실행했다.");
    }
}
