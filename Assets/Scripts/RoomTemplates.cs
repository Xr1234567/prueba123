using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms; 
    public GameObject[] leftRooms;

    public List<Vector2> coordinates = new List<Vector2>();
}
