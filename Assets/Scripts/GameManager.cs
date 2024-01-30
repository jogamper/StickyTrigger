using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        // make it a singelton
        if (instance == null)
            instance = this;
        else if (instance != this)
            // singleton: there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
    
    public void RestartGame()
    {
        Debug.Log("Restart Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}