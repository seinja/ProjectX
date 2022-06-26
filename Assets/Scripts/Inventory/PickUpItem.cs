using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class PickUpItem : MonoBehaviour
    {
        private Transform player;

        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _pickUpDistance = 1.5f;
        [SerializeField] private float _ttl = 10f;

        [SerializeField] private Item _item;
        [SerializeField] private int _count = 1;

        private void Awake()
        {
            player = GameManager.Instance.Player.transform;
        }

        private void Update()
        {
            _ttl -= Time.deltaTime;
            if (_ttl < 0) Destroy(gameObject);

            var distance = Vector3.Distance(transform.position, player.position);
        
            if(distance > _pickUpDistance) return;

            transform.position = Vector3.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);

            if (!(distance < 0.1f)) return;
        
            GameManager.Instance.Inventory.Add(_item, _count);
            
            Destroy(gameObject);
        }
    }
}
