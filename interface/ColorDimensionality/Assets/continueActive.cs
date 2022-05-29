using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueActive : MonoBehaviour
{
    public bool tl, tr, ll, lr;    

    public GameObject continueButtom;

    public void tlBool() { tl = true; }
    public void trBool() { tr = true; }
    public void llBool() { ll = true; }
    public void lrBool() { lr = true; }

    void Update()
    {
        if (tl == true && tr == true && ll == true && lr == true)
        {
            continueButtom.SetActive(true);
           
        }
    }
}