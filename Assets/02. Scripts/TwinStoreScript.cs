using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Correct_twin") { Debug.Log("correct"); }
        else if (other.gameObject.tag == "Incorrect_twin") { Debug.Log("incorrect"); }
    }
}
