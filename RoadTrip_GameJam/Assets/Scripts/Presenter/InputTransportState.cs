using UnityEngine;
using UnityEngine.InputSystem;

public class InputTransportState : MonoBehaviour
{
    public InputAction getTouchPosition;
    [SerializeField] private LayerMask selectableLayers;
    private GameModel _gameModel;

    private void OnEnable()
    {
        getTouchPosition.Enable();
        getTouchPosition.performed += GetTouchPosition_Performed;
    }

    private void Start()
    {
        _gameModel = FindAnyObjectByType<GamePresenter>().Model;
    }


    public void GetTouchPosition_Performed(InputAction.CallbackContext context)
    {
        Debug.Log("Touch");

        Vector2 worldPos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        Collider2D detectedCollider = Physics2D.OverlapPoint(worldPos, selectableLayers);
        if (detectedCollider != null)
        {
            Debug.Log("Touch something");

            switch (detectedCollider.gameObject.layer)
            {
                case 10:
                {
                        Debug.Log("Touch to build");
                        if(_gameModel == null)
                        {
                            Debug.Log("No gameModel");
                        }
                        _gameModel.SpawnSimpleTurret(detectedCollider.gameObject.transform.position);

                    break;
                }
            }
        }
    }
}
