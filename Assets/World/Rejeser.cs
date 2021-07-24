using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rejeser : MonoBehaviour
{
    public Transform Player;
    public GameObject GOJPlayer;
    public PsycheControl Psyche;
    public GameObject chunkStart;
    public GameObject[] chenk;


    public GameObject OBJSlender;
    private bool Slenser = false;
    private bool castle1 = false;

    int x = 1;
    int ix = -1;

    int z = 1;
    int iz = -1;

    private float SpawnTrigerSlender = 0;


    private void Start()
    {
        SpawnChank(chunkStart, new Vector2(0, 0));

        SpawnTrigerSlender = Random.Range(-0.1f, 0.1f);
    }


    private void LateUpdate()
    {
        SpawnChanks();

        ConstPsihine();


        if(Psyche.GetPsyche() > (0.3f + SpawnTrigerSlender) && Slenser == false)
        {
            GameObject s = Instantiate(OBJSlender, Player.position + (Player.forward * 40f), Quaternion.identity);
            s.GetComponent<Slender>().Player = Player;
            s.GetComponent<Slender>().PC = GOJPlayer.GetComponent<PsycheControl>();
            Slenser = true;
        }

    }

    private void SpawnChanks()
    {
        if (Player.position.x > 0)
        {
            if (Player.position.x <= (x * 50) && Player.position.x >= ((x - 1) * 50))
            {

                //Instantiate(chenk, new Vector3(x * 50f, 0, 0), Quaternion.identity);
                SpawnChank(new Vector2(x, 0));

                for (int i = 1; i < z; i++)
                {
                    //Instantiate(chenk, new Vector3(x * 50f, 0, i * 50f), Quaternion.identity);
                    SpawnChank(new Vector2(x, i));
                }

                for (int i = -1; i > iz; i--)
                {
                    //Instantiate(chenk, new Vector3(x * 50f, 0, i * 50f), Quaternion.identity);
                    SpawnChank(new Vector2(x, i));
                }

                x++;
            }
        }
        else
        {
            if (Player.position.x >= (ix * 50) && Player.position.x <= ((ix + 1) * 50))
            {

                //Instantiate(chenk, new Vector3(ix * 50f, 0, 0), Quaternion.identity);
                SpawnChank(new Vector2(ix, 0));

                for (int i = -1; i > iz; i--)
                {
                    //Instantiate(chenk, new Vector3(ix * 50f, 0, i * 50f), Quaternion.identity);
                    SpawnChank(new Vector2(ix, i));
                }

                for (int i = 1; i < z; i++)
                {
                    //Instantiate(chenk, new Vector3(ix * 50f, 0, i * 50f), Quaternion.identity);
                    SpawnChank(new Vector2(ix, i));
                }

                ix--;
            }
        }

        ///

        if (Player.position.z > 0)
        {
            if (Player.position.z <= (z * 50) && Player.position.z >= ((z - 1) * 50))
            {

                //Instantiate(chenk, new Vector3(0, 0, z * 50f), Quaternion.identity);
                SpawnChank(new Vector2(0, z));

                for (int i = 1; i < x; i++)
                {
                    //Instantiate(chenk, new Vector3(i * 50f, 0, z * 50f), Quaternion.identity);
                    SpawnChank(new Vector2(i, z));
                }

                for (int i = -1; i > ix; i--)
                {
                    //Instantiate(chenk, new Vector3(i * 50f, 0, z * 50f), Quaternion.identity);
                    SpawnChank(new Vector2(i, z));
                }

                z++;
            }
        }
        else
        {
            if (Player.position.z >= (iz * 50) && Player.position.z <= ((iz + 1) * 50))
            {

                //Instantiate(chenk, new Vector3(0, 0, iz * 50f), Quaternion.identity);
                SpawnChank(new Vector2(0, iz));

                for (int i = -1; i > ix; i--)
                {
                    //Instantiate(chenk, new Vector3(i * 50f, 0, iz * 50f), Quaternion.identity);
                    SpawnChank(new Vector2(i, iz));
                }

                for (int i = 1; i < x; i++)
                {
                    //Instantiate(chenk, new Vector3(i * 50f, 0, iz * 50f), Quaternion.identity);
                    SpawnChank(new Vector2(i, iz));
                }

                iz--;
            }
        }
    }

    public float ConstPsihine()
    {
        float i = ((x + (ix * -1) + z + (iz * -1)) - 4f) / 100f;

        return i;

    }

    private void SpawnChank(Vector2 V)
    {
        int i = Random.Range(0,101);

        if(i <= 95)
        {
            GameObject Chan = Instantiate(chenk[0], new Vector3(V.x * 50f, 0, V.y * 50f), Quaternion.identity);
            Chan.GetComponent<Chanc>().Player = Player;
        }
        else
        {
            if(castle1 == false)
            {
                GameObject Chan = Instantiate(chenk[1], new Vector3(V.x * 50f, 0, V.y * 50f), Quaternion.identity);
                Chan.GetComponent<Chanc>().Player = Player;
                castle1 = true;
            }
            else
            {
                GameObject Chan = Instantiate(chenk[0], new Vector3(V.x * 50f, 0, V.y * 50f), Quaternion.identity);
                Chan.GetComponent<Chanc>().Player = Player;
            }
        }
        
    }

    private void SpawnChank(GameObject g, Vector2 V)
    {
        GameObject Chan = Instantiate(g, new Vector3(V.x * 50f, 0, V.y * 50f), Quaternion.identity);
        Chan.GetComponent<Chanc>().Player = Player;
    }

}
