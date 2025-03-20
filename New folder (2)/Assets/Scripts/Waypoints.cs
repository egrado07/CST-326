using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake()
    {
        int count = transform.childCount;
        if (count == 0)
        {
            Debug.LogError(" No waypoints found! Make sure Waypoints object has children.", this);
            return;
        }

        points = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
