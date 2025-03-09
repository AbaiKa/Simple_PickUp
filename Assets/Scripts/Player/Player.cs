using UnityEngine;

namespace SPUPlayer
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private AInput inputComponent;
        [SerializeField] private PlayerMovement movementComponent;
        [SerializeField] private PlayerPickUp pickupComponent;
        [SerializeField] private PlayerUI uiComponent;

        private void Start()
        {
            Init();
        }
        public void Init()
        {
            uiComponent.Init();

            inputComponent.onMove.AddListener(movementComponent.Move);
            inputComponent.onLook.AddListener(movementComponent.Look);

            inputComponent.onInteraction.AddListener(pickupComponent.PickUp);
            pickupComponent.onPickUp.AddListener(uiComponent.OnItemPickUp);
            uiComponent.onDrop.AddListener(pickupComponent.OnDrop);
        }
    }
}
