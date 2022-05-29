using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fromTo : MonoBehaviour
{
    public GameObject from;
    public GameObject to;
    // Start is called before the first frame update
    public void FromTo()
    {
        to.SetActive(true);
        from.SetActive(false);
    }
}
