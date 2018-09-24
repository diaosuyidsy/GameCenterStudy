using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MonsterControl : MonoBehaviour
{
    public float PlayerAttackCD;
    public float MonsterAttackCD;
    private float MACD = 0f;
    private float PACD = 0f;
    private bool PlayerCanAttack = true;

    private float ActualAttackCD = 1f;
    public Animator MonsterAnimator;

    private bool MonsterInvincible = false;

    private bool PlayerDefensing = false;

    // Update is called once per frame
    void Update ()
    {
        MACD += Time.deltaTime;
        if (MACD >= MonsterAttackCD)
        {
            MACD = 0f;
            MonsterAnimator.SetTrigger ("Attack");
            StartCoroutine (Atk ());
        }

        if (!PlayerCanAttack)
        {
            PACD += Time.deltaTime;
            if (PACD >= PlayerAttackCD)
            {
                PACD = 0f;
                PlayerCanAttack = true;
            }
        }
    }

    private void OnMouseOver ()
    {
        // If right hold down
        if (Input.GetMouseButton (1))
        {
            PlayerDefensing = true;
        }
        // If left click down
        if (Input.GetMouseButtonDown (0))
        {
            if (PlayerCanAttack)
            {
                PlayerCanAttack = false;
                if (!MonsterInvincible)
                {
                    Fungus.Flowchart.BroadcastFungusMessage ("Monster Attacked");
                }
            }
        }
        if (Input.GetMouseButtonUp (1))
        {
            PlayerDefensing = false;
        }
    }

    void OnAttackPlayer ()
    {
        if (!PlayerDefensing)
        {
            // Call Flowchart MonsterAttack to indicate Player Loses Health
            Fungus.Flowchart.BroadcastFungusMessage ("Player Attacked");
        }
        else
        {
            Fungus.Flowchart.BroadcastFungusMessage ("Player Defensed");
        }
    }

    IEnumerator Atk ()
    {
        MonsterInvincible = true;
        while (ActualAttackCD >= 0f)
        {
            ActualAttackCD -= Time.deltaTime;
            if (ActualAttackCD <= 0.2f)
            {
                // Timer is up, Animation is attacking
                OnAttackPlayer ();
            }
            yield return null;
        }
        MonsterInvincible = false;

        ActualAttackCD = 0.8f;
    }
}
