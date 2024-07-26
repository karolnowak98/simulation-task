using GlassyCode.Simulation.Core.Utility;
using UnityEngine;
using UnityEngine.UIElements;

namespace GlassyCode.Simulation.Core.UI.Toolkit
{
    [RequireComponent(typeof(UIDocument))]
    public abstract class UIToolkitElement : GlassyMonoBehaviour
    {
        protected UIDocument Document;
        
        protected virtual void Awake()
        {
            TryGetComponent(out Document);
        }
    }
}