using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class DoorWindowContorller : MonoBehaviour
{

    private void OnMouseEnter ()
    {
        Fungus.Flowchart.BroadcastFungusMessage ("Trigger Window");
    }
}
