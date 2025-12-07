using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Pontuação")]
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("Coletáveis")]
    public int totalBolas; 
    private int bolasRestantes;

    private bool jogoAcabou = false;

    [Header("UI de Vitória")]
    public GameObject telaVitoria;

    [Header("UI de Derrota")]
    public GameObject telaDerrota;

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
        if (jogoAcabou) return;

        AddScore(pontos);
        bolasRestantes--;

        if (bolasRestantes <= 0)
        {
            jogoAcabou = true;
            StartCoroutine(FimDeJogoCoroutine());
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Pontos: " + score.ToString();
    }

    IEnumerator FimDeJogoCoroutine()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("MenuScene");
    }

    public void GameOverPorGasolina()
    {
        if (jogoAcabou) return;

        jogoAcabou = true;

        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
            player.StopPlayer();

        if (telaDerrota != null)
            telaDerrota.SetActive(true);

        Time.timeScale = 0f;
    }

    public void PlayerReachedGoal()
    {
        if (jogoAcabou) return;

        jogoAcabou = true;

        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
            player.StopPlayer();

        if (telaVitoria != null)
            telaVitoria.SetActive(true);

        Time.timeScale = 0f;
    }
}
