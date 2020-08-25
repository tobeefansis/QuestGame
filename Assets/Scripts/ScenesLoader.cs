using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{

    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }
    public void Load(int s)
    {
        SceneManager.LoadScene(s);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
