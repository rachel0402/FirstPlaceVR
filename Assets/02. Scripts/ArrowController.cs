using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject midPointVisual, arrowPrefab, arrowSpawnPoint;

    [SerializeField]
    private float arrowMaxSpeed = 10;

    public AudioClip Arrowsound;
    public AudioSource aud;


    public void PrepareArrow()
    {
       midPointVisual.SetActive(true);
        midPointVisual.gameObject.SetActive(true);
        Debug.Log("active");
    }

    public void ReleaseArrow(float strength)
    {
        midPointVisual.SetActive(false);


        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = midPointVisual.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(midPointVisual.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);
        aud.PlayOneShot(Arrowsound, 1);
    }
}















