using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour
{
    public GameObject[] Locations;

    private bool ClickedKey;
    private Vector3[] Locs;
    private int LocIndex = 0;

    private void Start ()
    {
        Locs = new Vector3[Locations.Length];
        for (int i = 0; i < Locations.Length; i++)
        {
            Locs[i] = Locations[i].transform.position;
        }
    }

    public void Appear ()
    {
        GetComponent<SpriteRenderer> ().enabled = true;
        GetComponent<BoxCollider2D> ().enabled = true;
        StartCoroutine (Teleport ());
    }

    private void OnMouseUp ()
    {
        ClickedKey = true;
        Fungus.Flowchart.BroadcastFungusMessage ("Found the key");

        GetComponent<SpriteRenderer> ().enabled = false;

    }

    IEnumerator Teleport ()
    {
        while (!ClickedKey)
        {
            transform.position = Locs[LocIndex++];
            if (LocIndex >= Locs.Length)
            {
                LocIndex = 0;
            }
            yield return new WaitForSeconds (15f);
        }
    }
}
