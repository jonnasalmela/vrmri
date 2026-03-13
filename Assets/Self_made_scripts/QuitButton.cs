using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void QuitGame()
    {
        // Works in Unity editor as well!
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}