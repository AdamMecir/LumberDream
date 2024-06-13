using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTickHandler : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;
    public const float TICK_TIMER_MAX = 1f;

    public int tick;
    public float tickTimer;

    private void Awake()
    {
        tick = 0;
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;
        if(tickTimer >= TICK_TIMER_MAX){
            tickTimer -= TICK_TIMER_MAX;
            tick++;
            if (OnTick != null) OnTick(this, new OnTickEventArgs { tick = tick });
        }
    }
}
