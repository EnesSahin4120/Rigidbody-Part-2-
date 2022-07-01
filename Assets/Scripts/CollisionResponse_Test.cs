using UnityEngine;

public class CollisionResponse_Test : MonoBehaviour
{
    [SerializeField] private Sphere ball1;
    [SerializeField] private Sphere ball2;

    private bool isIntersect;
    private bool isResponse;

    [SerializeField] private Transform collisionPoint;
    [SerializeField] private float arriveTime_to_Collision;

    private void Start()
    {
        Vector3 ball1_Direction = (collisionPoint.position - ball1.transform.position).normalized;
        Vector3 ball2_Direction = (collisionPoint.position - ball2.transform.position).normalized;

        float ball1_Dist = Vector3.Distance(collisionPoint.position, ball1.transform.position);
        float ball2_Dist = Vector3.Distance(collisionPoint.position, ball2.transform.position);

        float ball1_speed = ball1_Dist / arriveTime_to_Collision;
        float ball2_speed = ball2_Dist / arriveTime_to_Collision;

        ball1.velocity = ball1_speed * ball1_Direction;
        ball2.velocity = ball2_speed * ball2_Direction;
    }

    private void Update()
    {
        Mathematics.BoundingSphere(ball1);
        Mathematics.BoundingSphere(ball2);

        isIntersect = Mathematics.Sphere_SphereIntersection(ball1, ball2);

        if(isIntersect && !isResponse)
        {
            isResponse = true;
            PhysicsOperation.CollisionResponse(ball1, ball2);
        }
    }
}
