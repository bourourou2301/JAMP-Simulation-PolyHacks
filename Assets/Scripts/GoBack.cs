using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int sceneActuelleIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneActuelleIndex - 1);
        }
    }
}
