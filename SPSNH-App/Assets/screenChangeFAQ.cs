using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenChangeFAQ : MonoBehaviour
{
    public void MoveScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
