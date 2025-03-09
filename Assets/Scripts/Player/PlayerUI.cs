using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SPUPlayer
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private Button throwButton;

        public UnityEvent onDrop = new UnityEvent();
        
        private ItemComponent item;
        public void Init()
        {
            throwButton.onClick.AddListener(OnThrowButton);
        }
        public void OnItemPickUp(ItemComponent item)
        {
            this.item = item;
            titleText.gameObject.SetActive(true);
            throwButton.gameObject.SetActive(true);
            titleText.text = item.ID;
        }
        private void OnThrowButton()
        {
            item.Throw(5);
            titleText.gameObject.SetActive(false);
            throwButton.gameObject.SetActive(false);
            onDrop?.Invoke();
        }
    }
}