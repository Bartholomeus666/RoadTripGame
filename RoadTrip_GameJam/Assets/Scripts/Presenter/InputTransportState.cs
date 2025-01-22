using UnityEngine;
using UnityEngine.InputSystem;

public class InputTransportState : MonoBehaviour
{
    public InputAction getTouchPosition;

    private void OnEnable()
    {
        getTouchPosition.Enable();
        getTouchPosition.performed += GetTouchPosition_Performed;
    }

    public void GetTouchPosition_Performed(InputAction.CallbackContext context)
    {
        Debug.Log("Touch");
    }
}
