using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [field: SerializeField] public string ID { get; private set; }
    [SerializeField] private Rigidbody rigidbodyComponent;
    [SerializeField] private Collider colliderComponent;
    private Transform baseParent;
    public void Init(Transform parent)
    {
        baseParent = parent;
        transform.SetParent(baseParent);
        rigidbodyComponent.isKinematic = false;
    }
    public void PickUp(Transform newParent)
    {
        colliderComponent.isTrigger = true;
        rigidbodyComponent.isKinematic = true;
        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    public void Throw(float force)
    {
        colliderComponent.isTrigger = false;
        rigidbodyComponent.isKinematic = false;
        rigidbodyComponent.AddForce(transform.forward * force, ForceMode.Impulse);
        transform.SetParent(baseParent);
    }
}
