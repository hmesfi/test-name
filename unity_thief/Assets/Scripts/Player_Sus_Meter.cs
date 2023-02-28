using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sus_Meter : MonoBehaviour
{
    private float sus = 0f;
    [SerializeField] private float maxInconspicous = 100f;

    private void Start()
    {
        sus = maxInconspicous;
    }


    public void UpdateSus(float mod)
    {
        sus += mod;

        //this is for if we add ways for the player to reduce susness
        if (sus > maxInconspicous)
        {
            sus = maxInconspicous;
        } else if (sus <= 0f) {
            sus = 0f;
            Debug.Log("Player Respawn");
        }

    }
}
