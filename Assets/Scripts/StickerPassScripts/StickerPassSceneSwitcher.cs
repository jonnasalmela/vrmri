using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class SceneSwitcher : MonoBehaviour
{

    [SerializeField] private SceneAsset NextScene;
    private Scene CurrentScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwitchTheScene()
    {
        CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(NextScene.name);
    }

    public void ReturnToPreviousScene()
    {

    }
}
