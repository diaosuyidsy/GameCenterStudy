using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Light;
    public Flowchart flowchart;

    // Update is called once per frame
    void Update ()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Light.transform.position = new Vector3 (temp.x, temp.y, Light.transform.position.z);
    }
}
