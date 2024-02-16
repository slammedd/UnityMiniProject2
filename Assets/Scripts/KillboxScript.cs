using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillboxScript : MonoBehaviour
{
    private TimerScript timer;
    private PlayerMovement player;

    private void Start()
    {
        timer = FindObjectOfType<TimerScript>();
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            timer.stopped = true;
            timer.time = 0;
            other.transform.position = new Vector3(15, 0.5f, 3);
            player.points = 0;
            timer.stopped = false;
        }
    }
}
