using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
            {
                _panel.SetActive(!_panel.activeInHierarchy);
            }
        }
    }
}
