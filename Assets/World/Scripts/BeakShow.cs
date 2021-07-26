using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakShow : MonoBehaviour
{

    public Transform Player;
    public Chanc chank;
    public MeshRenderer[] MyMesh;

    bool show = true;

    private void Start()
    {
        Player = chank.Player;
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) > 60 && show == true)
        {
            foreach (var item in MyMesh)
            {
                item.enabled = false;
            }

            show = false;
        }

        if (Vector3.Distance(transform.position, Player.transform.position) < 59 && show == false)
        {
            foreach (var item in MyMesh)
            {
                item.enabled = true;
            }
            show = true;
        }

    }
}
