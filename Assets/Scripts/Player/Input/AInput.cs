using UnityEngine;
using UnityEngine.Events;

namespace SPUPlayer
{
    public abstract class AInput : MonoBehaviour
    {
        [SerializeField] protected LayerMask interactionMask;

        public UnityEvent<Vector2> onMove = new UnityEvent<Vector2>();
        public UnityEvent<Vector2> onLook = new UnityEvent<Vector2>();
        public UnityEvent<ItemComponent> onInteraction = new UnityEvent<ItemComponent>();

        protected abstract void HandleMovement();
        protected abstract void HandleLook();
        protected abstract void HandleInteraction();
    }
}