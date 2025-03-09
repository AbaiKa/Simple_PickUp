using UnityEngine;
using UnityEngine.Events;

namespace SPUPlayer
{
    public class PlayerPickUp : MonoBehaviour
    {
        [SerializeField] private Transform handRoot;

        public UnityEvent<ItemComponent> onPickUp = new UnityEvent<ItemComponent>();

        private ItemComponent item;
        public void PickUp(ItemComponent item)
        {
            if (this.item != null)
            {
                return;
            }

            this.item = item;
            item.PickUp(handRoot);
            onPickUp?.Invoke(item);
        }
        public void OnDrop()
        {
            item = null;
        }
    }
}
