using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chanc : MonoBehaviour
{
    public Transform Player;

    public MeshRenderer Mymesh;

    private void LateUpdate()
    {
        if(Vector3.Distance(transform.position, Player.transform.position) > 60)
        {
            Mymesh.enabled = false;
        }
        else if(Mymesh.enabled == false)
        {
            Mymesh.enabled = true;
        }
    }
}
