using UnityEngine;

namespace SPUPlayer
{
    public class MobileInput : AInput
    {
        [SerializeField] private Joystick joystickComponent;
        [SerializeField] private RectTransform joystickRect;
        [SerializeField] private float lookSensitivity = 0.1f;
        [SerializeField] private float interactionDistance = 3;

        private int lookFingerId = -1;
        private int moveFingerId = -1;

        private void Update()
        {
            HandleLook();
            HandleMovement();

            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    HandleInteraction();
                }
            }
        }

        protected override void HandleInteraction()
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, interactionMask))
            {
                if (hit.collider.TryGetComponent(out ItemComponent item))
                {
                    onInteraction?.Invoke(item);
                }
            }
        }

        protected override void HandleLook()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == moveFingerId)
                    continue;

                if (touch.phase == TouchPhase.Began && lookFingerId == -1 && 
                    !RectTransformUtility.RectangleContainsScreenPoint(joystickRect, touch.position))
                {
                    lookFingerId = touch.fingerId;
                }

                if (touch.fingerId == lookFingerId)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        Vector2 delta = touch.deltaPosition * lookSensitivity;
                        onLook?.Invoke(delta);
                    }
                    else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                    {
                        lookFingerId = -1;
                    }
                }
            }
        }

        protected override void HandleMovement()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == lookFingerId)
                    continue;

                if (touch.phase == TouchPhase.Began && moveFingerId == -1)
                {
                    moveFingerId = touch.fingerId;
                }

                if (touch.fingerId == moveFingerId)
                {
                    onMove?.Invoke(joystickComponent.Direction);

                    if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                    {
                        moveFingerId = -1;
                    }
                }
            }
        }
    }
}