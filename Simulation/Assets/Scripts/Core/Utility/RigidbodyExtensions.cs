using UnityEngine;

namespace GlassyCode.Simulation.Core.Utility
{
    public static class RigidbodyExtensions
    {
        public static void SetRandomDirectionVelocity(this Rigidbody rb, float speed)
        {
            var randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        
            rb.velocity = randomDirection * speed;
        }
        
        public static void SetRandomDirectionVelocityXZ(this Rigidbody rb, float speed)
        {
            var randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        
            rb.velocity = randomDirection * speed;
        }
    }
}