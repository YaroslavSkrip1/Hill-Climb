using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D carRigidBody;
    [SerializeField] private Rigidbody2D backTire;
    [SerializeField] private Rigidbody2D frontTire;
    [SerializeField] private float speed = 100;
    [SerializeField] private float carTorque = 10;

    private float movement = 0f;
    
    private void FixedUpdate()
    {
        backTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
        frontTire.AddTorque(-movement * speed * Time.fixedDeltaTime);
        carRigidBody.AddTorque(-movement * carTorque * Time.fixedDeltaTime);
    }
    public void SetMovement(float direction) => movement = direction;
}