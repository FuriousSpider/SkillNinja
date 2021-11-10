using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager
{
    long timeStamp;
    long interval;
    long minInterval;

    public TimeManager(long interval, long minInterval) {
        this.interval = interval;
        this.minInterval = minInterval;
    }

    public void Start() {
        timeStamp = Now();
    }

    public bool HasIntervalPassed() {
        if (timeStamp + interval < Now()) {
            timeStamp = Now();
            return true;
        } else {
            return false;
        }
    }

    public void DecreaseIntervalBy(long shortenBy) {
        if (this.interval > this.minInterval) {
            this.interval -= shortenBy;
        }
    }

    public long Now() {
        return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }
}
