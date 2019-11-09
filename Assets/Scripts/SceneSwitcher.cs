using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToScene(int sceneIndex) // function used to change scenes/levels 
    {
      SceneManager.LoadScene(sceneIndex); //loads the scene with the index of the given input
    }
}
