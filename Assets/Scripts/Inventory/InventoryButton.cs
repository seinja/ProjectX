using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    public class InventoryButton : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _countText;

        int myIndex;

        public void SetIndex(int index)
        {
            myIndex = index;
        }

        public void Set(ItemSlot item)
        {
            _icon.sprite = item.Item.Icon;

            if (item.Item.Stackable)
            {
                _countText.gameObject.SetActive(true);
                _countText.text = item.Count.ToString();
            }
            else
            {
                _countText.gameObject.SetActive(false);
            }
        }

        public void Clean()
        {
            _icon.sprite = null;
            _icon.gameObject.SetActive(false);
            
            _countText.gameObject.SetActive(false);
        }

    }
}
