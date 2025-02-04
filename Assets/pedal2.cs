using UnityEngine;

public class PaddleController2 : MonoBehaviour
{
    public float rotationAngle = 45f; // Maximum rotation angle
    public KeyCode leftKey = KeyCode.LeftArrow; // Key for left paddle
    public KeyCode rightKey = KeyCode.RightArrow; // Key for right paddle
    public float bounceForce = 10f; // Bounce force applied to the ball

    private Quaternion initialRotation; // Initial rotation of the paddle
    private Rigidbody ballRigidbody; // Ball's Rigidbody component

    void Start()
    {
        initialRotation = transform.rotation; // Store the initial rotation
        ballRigidbody = GameObject.FindWithTag("Ball").GetComponent<Rigidbody>(); // Find the ball's Rigidbody component
    }

    void Update()
    {
        if (Input.GetKey(leftKey))
        {
            RotatePaddle(rotationAngle); // Rotate paddle by 45 degrees when left key is pressed
            MakeSurfaceBouncy(); // Activate the bouncy surface behavior
        }
        else if (Input.GetKey(rightKey))
        {
            RotatePaddle(-rotationAngle); // Rotate paddle by -45 degrees when right key is pressed
            MakeSurfaceBouncy(); // Activate the bouncy surface behavior
        }
        else
        {
            ResetRotation(); // Return to initial rotation when no keys are pressed
        }
    }

    void RotatePaddle(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle); // Rotate around the Z axis
    }

    void ResetRotation()
    {
        transform.rotation = initialRotation; // Reset to the initial rotation
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && (Input.GetKey(leftKey) || Input.GetKey(rightKey)))
        {
            // Apply bounce force to the ball
            Vector3 bounceDirection = collision.contacts[0].normal;
            ballRigidbody.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }

    void MakeSurfaceBouncy()
    {
        // This function can be used to add any additional behavior when the keys are pressed
    }
}
