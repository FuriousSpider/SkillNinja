using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager
{
    public static Vector3 GetRandomPositionForZone(Zone zone) {
        return new Vector3(Random.Range(zone.GetMinX(), zone.GetMaxX()), Random.Range(zone.GetMinY(), zone.GetMaxY()), 0);
    }
}
