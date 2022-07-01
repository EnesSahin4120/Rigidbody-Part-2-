using UnityEngine;

public class PhysicsBody : MonoBehaviour
{
    [HideInInspector] public Vector3 center;

    public float mass;
    public Vector3 velocity;
    public Vector3 angularVelocity;

    protected float rotX;
    protected float rotY;
    protected float rotZ;

    [Range(0, 1)]
    public float elasticity;

    protected virtual void FixedUpdate()
    {
        SetVelocity();
        SetAngularVelocity();
    }

    public virtual void AddForce(Vector3 forceVector)
    {
        Vector3 accelerationVector = forceVector / mass;
        velocity += accelerationVector * Time.deltaTime;
    }

    protected virtual void SetVelocity()
    {
        transform.position += velocity * Time.deltaTime;
    }

    protected virtual void SetAngularVelocity()
    {
        rotX += (180 / Mathf.PI) * angularVelocity.x * Time.deltaTime;
        rotY += (180 / Mathf.PI) * angularVelocity.y * Time.deltaTime;
        rotZ += (180 / Mathf.PI) * angularVelocity.z * Time.deltaTime;

        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }

    public virtual void AddTorque(Vector3 _torquePosition, Vector3 _torqueDirection)
    {
        Vector3 radiusVector = _torquePosition - transform.position;
        Vector3 torqueVector = Vector3.Cross(radiusVector, _torqueDirection);
        angularVelocity += torqueVector * Time.deltaTime;
    }
}