using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Bonk");
        Destroy(gameObject);
    }
}
