using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string gameSceneName = "GameScene";

    public void StartGame()
    {
        Debug.Log("Botão clicado!");
        SceneManager.LoadScene(gameSceneName);
    }
}