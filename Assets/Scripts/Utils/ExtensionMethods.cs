using UnityEngine;


public static class MyExtensions
{
    public static Vector3 Snap(this Vector3 vector, float distanceStap = 1)
    {
        float snapX = vector.x.Snap(distanceStap);
        float snapY = vector.y.Snap(distanceStap);
        float snapZ = vector.z.Snap(distanceStap);

        return new Vector3(snapX, snapY, snapZ);
    }
    public static float Snap(this float value, float distance = 1)
    {
        return Mathf.Round(value / distance) * distance;
    }
}

