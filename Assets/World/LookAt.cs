using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Slender S;

    private void Update()
    {
        transform.LookAt(S.Player);
    }
}
