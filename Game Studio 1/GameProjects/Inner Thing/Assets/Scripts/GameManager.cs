using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject Light;
    public Flowchart flowchart;
    public SpriteRenderer JailBlankMask;
    public SpriteRenderer PartyBlankMask;
    public AudioClip LightningSoundFX;
    public AudioClip CandleLitSFX;
    public Image BloodScreen;
    public Animator LighteningAnimator;
    public float LighteningCD = 10f;

    private bool stopLightning = false;

    private void Awake()
    {
        GM = this;
    }

    private void Start()
    {
        StartCoroutine(startLightening());
    }

    IEnumerator startLightening()
    {
        while (!stopLightning)
        {
            LighteningAnimator.SetTrigger("Struck");
            GetComponent<AudioSource>().clip = LightningSoundFX;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(LighteningCD);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Light.transform.position = new Vector3(temp.x, temp.y, Light.transform.position.z);
    }

    public void JailTransform()
    {
        Color temp = JailBlankMask.color;
        temp.a += 0.1f;
        JailBlankMask.color = temp;
    }

    public void PartyTransform()
    {
        Color temp = PartyBlankMask.color;
        temp.a += 0.25f;
        PartyBlankMask.color = temp;
    }

    public void BloodScreenTransform()
    {
        Color temp = BloodScreen.color;
        temp.a += 0.2f;
        BloodScreen.color = temp;
    }

    public void CandleLit()
    {
        GetComponent<AudioSource>().clip = CandleLitSFX;
        GetComponent<AudioSource>().Play();
    }

    public void StopLight()
    {
        stopLightning = true;
    }

}
