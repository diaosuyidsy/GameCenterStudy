﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SpiderHoleControl : MonoBehaviour
{

    private void OnMouseEnter()
    {
        Fungus.Flowchart.BroadcastFungusMessage("Trigger Spider Hole");
    }
}
