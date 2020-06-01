using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterLifetime : MonoBehaviour
{

    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", lifetime);
    }

    // Update is called once per frame
    
        
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
