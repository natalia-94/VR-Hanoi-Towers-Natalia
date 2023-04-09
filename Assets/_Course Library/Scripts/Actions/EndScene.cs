using UnityEngine.SceneManagement;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
