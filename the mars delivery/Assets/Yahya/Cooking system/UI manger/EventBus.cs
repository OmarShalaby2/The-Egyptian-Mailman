using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    

    public event Action CallSpawnSquibble;

    public void TriggerSpawnSquibble()
    {
        CallSpawnSquibble?.Invoke();
    }




    // private SquibbleSpawner squibbleSpawner;
    // void Start()
    // {
    //     eventBus = FindObjectOfType<EventBus>();
    // }
    // public void TriggerSpawnSquibble()
    // {
    //     squibbleSpawner.SpawnSquibbles();
    //     squibbleSpawner.SpawnSquibblesInGame();
    // }

}
