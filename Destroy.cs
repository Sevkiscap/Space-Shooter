using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] int damage = 100; 

    public int GetDamage()
    {
        return 100;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
