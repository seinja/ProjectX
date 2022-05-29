using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(20, 20);
    private Building[,] _grid;
    private Building _flyingBuilding;

    [SerializeField] private Building _house;

    private Camera _mainCamera;

    private void Awake()
    {
        _grid = new Building[GridSize.x, GridSize.y];

        _mainCamera = Camera.main;
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (_flyingBuilding != null)
        {
            Destroy(_flyingBuilding);
        }

        _flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if (_flyingBuilding != null)
        {
            Plane groundPlane = new Plane(Vector3.forward, Vector3.zero);
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPostion = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPostion.x);
                int y = Mathf.RoundToInt(worldPostion.y);

                bool available = !(x < 0 || x > GridSize.x - _flyingBuilding.Size.x);

                available = !(y < 0 || y > GridSize.y - _flyingBuilding.Size.y);





                _flyingBuilding.transform.position = new Vector3(x, y, 0);

                if (available && Input.GetMouseButtonDown(0)) 
                {
                    _flyingBuilding = null;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartPlacingBuilding(_house);
        }
    }
}
