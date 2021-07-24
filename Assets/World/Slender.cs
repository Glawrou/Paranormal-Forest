using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slender : MonoBehaviour
{
    public Transform Player;
    public AudioSource Scream, Breath;
    public Animator Anim;
    public PsycheControl PC;

    public SkinnedMeshRenderer[] MyMesh;

    bool TBreath = false; bool TScheam = false;

 

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y, Player.position.z), Time.deltaTime * 3.5f);
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(Player.position.x, 0, Player.position.z));

        if (Vector3.Distance(transform.position, Player.transform.position) < 35 && TBreath == false)
        {
            Anim.SetTrigger("Wall");
        }
        
        if (Vector3.Distance(transform.position, Player.transform.position) < 35 && TBreath == false)
        {
            Breath.Play();
            TBreath = true;
            StartCoroutine(Dead(14));
        }

        if (Vector3.Distance(transform.position, Player.transform.position) < 25 && TScheam == false)
        {
            Scream.Play();
            TScheam = true;
            StartCoroutine(Dead(2));
            
        }

    }

    IEnumerator Dead(int n)
    {
        yield return new WaitForSeconds(n);

        foreach (var item in MyMesh)
        {
            item.enabled = false;
        }

        if(n < 5 )PC.AddPsyche(0.2f);

        StartCoroutine(PC.ScreamPanel());

        yield return new WaitForSeconds(20);

        Destroy(gameObject);
    }

    
}
