using UnityEngine;
using UnityEngine.InputSystem;

public class LandingPhysics : MonoBehaviour
{
    [Header("Input Settings")]
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private string actionMapName = "PlayerControls";
    [SerializeField] private string actionName = "Movement";

    [Header("Movement Settings")]
    [SerializeField] private float thrustForce = 10f;        // Force applied when thrusting
    [SerializeField] private float maxSpeed = 20f;           // Maximum speed
    [SerializeField] private float rotationSpeed = 180f;     // Degrees per second
    [SerializeField] private float accelerationRate = 2f;    // How quickly the ship reaches max speed
    [SerializeField] private float decelerationRate = 1f;    // How quickly the ship slows down

    private Rigidbody2D rb;
    private InputAction movementAction;
    private Vector2 inputVector;
    private float currentThrust;
    private Vector2 velocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SetupInputActions();
    }

    private void SetupInputActions()
    {
        if (inputActions == null)
        {
            inputActions = new InputActionAsset();
            var actionMap = inputActions.AddActionMap(actionMapName);
            movementAction = actionMap.AddAction(actionName, InputActionType.Value);
            movementAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/upArrow")
                .With("Down", "<Keyboard>/downArrow")
                .With("Left", "<Keyboard>/leftArrow")
                .With("Right", "<Keyboard>/rightArrow");
        }
        else
        {
            var actionMap = inputActions.FindActionMap(actionMapName, true);
            movementAction = actionMap.FindAction(actionName, true);
        }

        movementAction.Enable();
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void HandleRotation()
    {
        inputVector = movementAction.ReadValue<Vector2>();
        float rotationInput = inputVector.x;

        // Rotate the ship based on input
        float rotationAmount = -rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotationAmount);
    }

    private void HandleThrust()
    {
        // Gradually increase/decrease thrust based on up arrow input
        if (inputVector.y > 0)
        {
            currentThrust = Mathf.Min(currentThrust + accelerationRate * Time.deltaTime, 1f);
        }
        else
        {
            currentThrust = Mathf.Max(currentThrust - decelerationRate * Time.deltaTime, 0f);
        }
    }

    private void ApplyMovement()
    {
        if (currentThrust > 0)
        {
            // Calculate direction based on current rotation
            float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 thrustDirection = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle));

            // Apply force in the direction the ship is facing
            rb.AddForce(thrustDirection * thrustForce * currentThrust);

            // Clamp velocity to max speed
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }
    }

}