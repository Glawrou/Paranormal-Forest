using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWood : MonoBehaviour
{

    public Transform player;
    public Chanc chank;
    public GameObject[] Wood = new GameObject[5];
    public Collider MyCollider;

    GameObject MyWood; bool Spawdened = false;

    private void Start()
    {
        player = chank.Player;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if(distance > 40 && Spawdened == true)
        {
            Spawdened = false;
            if (MyCollider != null) MyCollider.enabled = false;
            Destroy(MyWood);
        }
        else if(distance <= 40 && Spawdened == false)
        {
            Spawdened = true;
            if(MyCollider != null) MyCollider.enabled = true;
            MyWood = Instantiate(Wood[Random.Range(0, 5)], transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        Destroy(MyWood);
    }
}
