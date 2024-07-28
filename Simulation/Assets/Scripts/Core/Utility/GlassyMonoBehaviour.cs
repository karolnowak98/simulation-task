using UnityEngine;

namespace GlassyCode.Simulation.Core.Utility
{
    public abstract class GlassyMonoBehaviour : MonoBehaviour
    {
        public bool IsActive => gameObject.activeSelf;
        public Transform Transform => transform;
        public Vector3 Position => transform.position;
        
        public void Enable()
        {
            gameObject.SetActive(true);
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
        
        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
        
        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
        
        public void DestroyImmediate()
        {
            DestroyImmediate(gameObject);
        }
    }
}