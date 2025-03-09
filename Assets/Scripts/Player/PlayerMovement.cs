using UnityEngine;

namespace SPUPlayer
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 2;
        [SerializeField] private Rigidbody rigidbodyComponent;
        [SerializeField] private Transform cameraTransform;
        public void Move(Vector2 direction)
        {
            Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
            moveDirection = moveDirection.normalized;
            moveDirection = transform.TransformDirection(moveDirection);
            rigidbodyComponent.velocity = new Vector3(moveDirection.x * speed, rigidbodyComponent.velocity.y, moveDirection.z * speed);
        }

        private float pitch;
        public void Look(Vector2 delta)
        {
            pitch = Mathf.Clamp(pitch - delta.y, -90f, 90f);
            cameraTransform.localRotation = Quaternion.Euler(pitch, 0, 0);
            transform.Rotate(transform.up, delta.x);
        }
    }
}