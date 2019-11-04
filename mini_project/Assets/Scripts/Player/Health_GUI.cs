using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_GUI : MonoBehaviour
{
    public int numOfHearts; // Maximale Anzahl an Herzen die der Spieler haben kann. (Darf nicht größer als die Länge des hearts array sein!)

    private int health; // Anzahl der Herzen die der Spieler aktuell hat

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        health = numOfHearts;
    }

    void Update(){

        if( health > numOfHearts) {
            health  = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if( i < health) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if( i < numOfHearts ) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    // Wenn die Leben des Spielers sich verändern, muss die Herzanzeige angepasst werden.
    public void SetHealth( float currentHp, float maxHP )
    {
        /* health ist vom Typ int da nur ganze Herzen dargestellt werdne können.
         * Da der Spieler einen float Wert als aktuelles Leben hat, muss dieser in int konvertiert werden. Um nicht zu viele Leben anzuzeigen werdne die Leben abgerundet.*/
        health = (int) Mathf.Floor( currentHp / maxHP * numOfHearts);
    }
}
