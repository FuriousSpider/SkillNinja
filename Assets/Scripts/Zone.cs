using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone
{
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    public Zone(float minX, float maxX, float minY, float maxY) {
        this.minX = minX;
        this.maxX = maxX;
        this.minY = minY;
        this.maxY = maxY;
    }

    public float GetMinX() {
        return minX;
    }

    public float GetMaxX() {
        return maxX;
    }

    public float GetMinY() {
        return minY;
    }

    public float GetMaxY() {
        return maxY;
    }

    public float GetWidth() {
        return maxX - minX;
    }

    public float GetHeight() {
        return maxY - minY;
    }

    public float GetHorizontalCenter() {
        return (maxX + minX) / 2;
    }

    public float GetYByFraction(float fraction) {
        return minY + (maxY - minY) * fraction;
    }

    public Vector3 GetCenter() {
        return new Vector3((maxX + minX) / 2, (maxY + minY) / 2, 0);
    }

    public Vector2 GetSize() {
        return new Vector2(maxX - minX, maxY - minY);
    }
}
