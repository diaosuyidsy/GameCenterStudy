﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CandleController : MonoBehaviour
{
    public GameObject CandleUnlit;
    public GameObject Candle_Animation;
    public GameObject Skeleton;

    private void OnMouseUp()
    {
        // Lit the candle
        CandleUnlit.SetActive(false);
        Candle_Animation.SetActive(true);
        // Broadcast a message
        Fungus.Flowchart.BroadcastFungusMessage("Candle is lit");
        Skeleton.SetActive(true);
        GameManager.GM.CandleLit();
    }
}
