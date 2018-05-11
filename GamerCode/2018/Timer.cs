using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float startTime;
    float currentTime;

    public enum TIMERPHASE { NOTHING, START, TIMING, FINISH };
    public TIMERPHASE timerPhase;

    public float waitTime;

    // Update is called once per frame
    void FixedUpdate () {

        if (timerPhase == TIMERPHASE.START)
        {
            startTime = Time.time;
            timerPhase = TIMERPHASE.TIMING;
        }

        if(timerPhase == TIMERPHASE.TIMING)
        {
            currentTime = Time.time - startTime;

            if (currentTime > waitTime)
            {
                timerPhase = TIMERPHASE.FINISH;
            }
        }
    }

    public float getCurrentTime()
    {
        return currentTime;
    }

    public float getStartTime()
    {
        return startTime;
    }
}
