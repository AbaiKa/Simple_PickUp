using UnityEngine;

namespace SPUPlayer
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private AInput inputComponent;
        [SerializeField] private PlayerMovement movementComponent;

        private void Start()
        {
            Init();
        }
        public void Init()
        {
            inputComponent.onMove.AddListener(movementComponent.Move);
            inputComponent.onLook.AddListener(movementComponent.Look);
        }
    }
}
