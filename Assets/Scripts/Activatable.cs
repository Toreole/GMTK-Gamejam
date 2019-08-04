using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class Activatable : MonoBehaviour
{
    public abstract void Activate();

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
