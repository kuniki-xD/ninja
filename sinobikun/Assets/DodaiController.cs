using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodaiController : MonoBehaviour
{
    void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }
}
