using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class KeyController : MonoBehaviour
{
    private void OnMouseEnter ()
    {
        Debug.Log ("hello");
        Fungus.Flowchart.BroadcastFungusMessage ("Found the key");

    }
}
