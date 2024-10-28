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
        // [�������� 1] actionAsset���� Space �׼��� ã�� Ȱ��ȭ�մϴ�.
        // InputActionAsset���� "Space"��� �̸��� InputAction�� ã�´�.
        // �׷��� �� �ڵ常���δ� InputAction�� Ȱ��ȭ ���� �ʴ´�. InputAction�� Ȱ��ȭ�Ϸ��� Enable �޼��带 ȣ���ؾ� �Ѵ�.
        spaceAction = actionAsset.FindAction("Space");
        if (spaceAction != null )
        {
            spaceAction.Enable();
        }
    }

    // [�������� 2] ContextMenu ��Ʈ����Ʈ�� Ȱ���ؼ� �ν�����â���� ������ �� �ֵ��� ��
    [ContextMenu("RebindSpaceToEscape")]
    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;

        // [�������� 3] ���� ���ε��� ��Ȱ��ȭ�ϰ� �� Ű�� ����ε�
        spaceAction.ApplyBindingOverride("<Keyboard>/Escape");


        Debug.Log("Done!");
    }

    void OnDestroy()
    {
        // �׼��� ��Ȱ��ȭ�մϴ�.
        spaceAction?.Disable();
    }

    void OnSpace()
    {
        Debug.Log("�����ߴ�.");
    }
}
