using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Pontuação")]
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("Coletáveis")]
    public int totalBolas; 
    private int bolasRestantes;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bolasRestantes = totalBolas;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void BolaColetada(int pontos)
    {
        AddScore(pontos);
        bolasRestantes--;

        if (bolasRestantes <= 0)
        {
            FimDeJogo();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Pontos: " + score.ToString();
    }

    void FimDeJogo()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
