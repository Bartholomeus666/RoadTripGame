using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSneakyState : MonoBehaviour
{
    public InputAction DrawLine;

    [SerializeField] private LayerMask selectableLayers;
    private LineRenderer _lineRenderer;
    private SneakyPlayerModel _playerModel;
    private bool _isDrawing = false;
    private Vector3 _previousPosition;
    private int _lineIndex = 0;
    

    private void OnEnable()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        DrawLine.Enable();
        //DrawLine.started += StartLine;
        //DrawLine.canceled += CancelLine;
        DrawLine.performed += DrawPlayerLine;
    }

    private void Start()
    {
        _playerModel = FindAnyObjectByType<SneakyPlayerPresenter>().Model;
    }


    private void DrawPlayerLine(InputAction.CallbackContext context)
    {

        Vector2 worldPos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        Collider2D detectedCollider = Physics2D.OverlapPoint(worldPos, selectableLayers);

        if (!_isDrawing && detectedCollider != null)
        {
            Debug.Log("Player Found");

            _isDrawing = true;
            _previousPosition = worldPos;
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(0, worldPos);
            _lineIndex++;
        }
        else if (_isDrawing)
        {
            if (Vector2.Distance(worldPos, _previousPosition) > 0.01)
            {
                Debug.Log("Point Added");

                _lineRenderer.positionCount++;
                _lineRenderer.SetPosition(_lineIndex, worldPos);
                _previousPosition = worldPos;
                _lineIndex++;
            }
        }

    }


    private void Update()
    {
        if (_isDrawing && !IsTouchingScreen())
        {
            Debug.Log("Touch Released");

            _playerModel.FollowLine(_lineRenderer);
            _isDrawing = false;
        }
    }

    private bool IsTouchingScreen()
    {
        return (Mouse.current != null && Mouse.current.leftButton.isPressed) ||
               (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed);
    }





    private void OnDisable()
    {
        //DrawLine.started -= StartLine;
        //DrawLine.canceled -= CancelLine;
        DrawLine.performed -= DrawPlayerLine;
        DrawLine.Disable();
    }
}

