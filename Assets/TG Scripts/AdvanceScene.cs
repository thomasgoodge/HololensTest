using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class AdvanceScene : MonoBehaviour
{
    public void AdvanceLevel(string sceneIndex)
    {
       SceneManager.LoadScene(sceneIndex);
    }


}



