using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SwordControl : MonoBehaviour
{

    private void OnMouseUp ()
    {
        Fungus.Flowchart.BroadcastFungusMessage ("Try to pick up sword");
    }
}
