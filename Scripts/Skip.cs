using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public void JumpSceneDay()
    {
        
        SceneManager.LoadScene("Day");

    }

    public void JumpSceneNight()
    {
        SceneManager.LoadScene("Night");

    }
}
