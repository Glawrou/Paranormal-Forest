using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtemLoh : MonoBehaviour
{

    public AudioSource Win;

    private void Start()
    {
        
    }


    IEnumerator DesWait()
    {
        Win.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
