using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Utils
{
    public static long GetCurrentTime() {
        return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }

    public static bool IsAfter(long time) {
        return time - GetCurrentTime() < 0;
    }

    public static long GetFutureTime(long time) {
        return GetCurrentTime() + time;
    }
}
