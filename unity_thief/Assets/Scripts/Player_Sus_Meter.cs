using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sus_Meter : MonoBehaviour
{
    private float sus = 0f;
    [SerializeField] private float minSus = 0f;

    private void Start()
    {
        sus = minSus;
    }


    public void UpdateSus(float mod)
    {
        sus += mod;

        //this is for if we add ways for the player to reduce susness
        if (sus < minSus)
        {
            sus = minSus;
        }
        else if (sus >= 5f)
        {
            sus = 5f;
            Debug.Log("Player Player too sus quit game");
        }

    }

    public float printSus()
    {
        return sus;
    }
}
