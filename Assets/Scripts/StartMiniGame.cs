using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMiniGame : MonoBehaviour
{

    

    public void SceneChange()
    {
        SceneManager.LoadScene(4);
    }
}
