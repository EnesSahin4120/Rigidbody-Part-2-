using UnityEngine;

public class PhysicsOperation : MonoBehaviour
{
    static public void CollisionResponse(Sphere sphere1, Sphere sphere2) 
    {
        Vector3 collisionNormal = sphere2.center - sphere1.center;
        Vector3 relativeVelocity = sphere1.velocity - sphere2.velocity;

        float vDotN = Vector3.Dot(relativeVelocity, collisionNormal);
        float modifiedVel = vDotN / (1.0f / sphere1.mass + 1.0f / sphere2.mass);

        float j1 = -(1.0f + sphere1.elasticity) * modifiedVel;
        float j2 = -(1.0f + sphere2.elasticity) * modifiedVel;

        sphere1.velocity += j1 / sphere1.mass * collisionNormal;
        sphere2.velocity -= j2 / sphere2.mass * collisionNormal;
    }
}
