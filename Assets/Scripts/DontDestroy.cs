using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static string valueToKeep;
   


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

   
}
