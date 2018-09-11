using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DoorKnobController : MonoBehaviour
{

    private void OnMouseDown ()
    {
        Fungus.Flowchart.BroadcastFungusMessage ("Try to open door");
    }
}
