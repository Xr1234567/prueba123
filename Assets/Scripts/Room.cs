using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Vector2 coordinate = Vector2.zero;
    private RoomSpawner[] roomSpawners;

    RoomTemplates templates;

    private void Awake()
    {
        roomSpawners = GetComponentsInChildren<RoomSpawner>();

        templates = FindFirstObjectByType<RoomTemplates>();

        Invoke("Spawn", 0.1f);
    }

    private void Start()
    {
        templates.coordinates.Add(coordinate);
    }

    private void Spawn()
    {
        for (int i = 0; i < roomSpawners.Length; i++)
        {

            RoomSpawner roomSpawner = roomSpawners[i];
            Vector2 spawnerCoordinate = this.coordinate;
            switch (roomSpawner.openSide)
            {
                case RoomSpawner.Side.Bottom:
                    spawnerCoordinate.y = coordinate.y - 1;
                    break;
                case RoomSpawner.Side.Top:
                    spawnerCoordinate.y = coordinate.y + 1;
                    break;
                case RoomSpawner.Side.Left:
                    spawnerCoordinate.x = coordinate.x - 1;
                    break;
                case RoomSpawner.Side.Right:
                    spawnerCoordinate.x = coordinate.x + 1;
                    break;
            }

            roomSpawner.Initialize(spawnerCoordinate, templates);

            roomSpawner.Spawn();
        }
    }

    public void SetCoordinates(Vector2 coordinates)
    {
        this.coordinate = coordinates;
    }
}
