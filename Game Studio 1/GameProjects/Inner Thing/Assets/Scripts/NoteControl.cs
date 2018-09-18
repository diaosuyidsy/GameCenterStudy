using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class NoteControl : MonoBehaviour
{

    private void OnMouseUp ()
    {
        Fungus.Flowchart.BroadcastFungusMessage ("Note Is Found");
        gameObject.SetActive (false);
    }
}
