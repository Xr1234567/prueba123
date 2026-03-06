using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private Vector2 coordinate;
    public enum Side { Bottom, Top, Left, Right }
    public Side openSide;
    //public GameObject[] prefabs;
    //1 Need Bottom door
    //2 Need Top door
    //3 Need Left door
    //4 Need Right door

    RoomTemplates templates;

    private int rand;
    private bool spawner = false;

    //void Start()
    //{
    //    //templates=GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    //    templates = FindFirstObjectByType<RoomTemplates>();

    //    //Invoke(nameof(Spawn), 0.1f);
    //}

    public void Initialize(Vector2 coordinate, RoomTemplates templates)
    {
        this.coordinate = coordinate;
        this.templates = templates;
    }


    public void Spawn()
    {
        if (templates.coordinates.Contains(coordinate))
        {
            spawner = true;
        }


        if (spawner == false)
        {
            if (openSide == Side.Bottom)
            {
                //Need Bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                GameObject room = Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                room.GetComponent<Room>().SetCoordinates(coordinate);
            }
            else if (openSide == Side.Top)
            {
                //Need Top door
                rand = Random.Range(0, templates.topRooms.Length);
                GameObject room = Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                room.GetComponent<Room>().SetCoordinates(coordinate);
            }
            else if (openSide == Side.Left)
            {
                //Need Left door  
                rand = Random.Range(0, templates.leftRooms.Length);
                GameObject room = Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                room.GetComponent<Room>().SetCoordinates(coordinate);
            }
            else if (openSide == Side.Right)
            {
                //Need Right door
                rand = Random.Range(0, templates.rightRooms.Length);
                GameObject room = Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                room.GetComponent<Room>().SetCoordinates(coordinate);
            }
            spawner = true;

        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}