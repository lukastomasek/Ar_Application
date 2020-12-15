using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public enum GameTurns
{
    playerTurn, OponentTurn
};

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] Button[] playerBtns;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    public GameObject ending;
    public TMPro.TextMeshProUGUI winTxt;

    [HideInInspector] public bool playerWon = false;

    TargetFinder finder;
    private void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;
#else
 Debug.unityLogger.logEnabled = false;
#endif

        if (instance == null) instance = this;

        if (player == null)
            player = FindObjectOfType<Player>();

        if (enemy == null)
            enemy = FindObjectOfType<Enemy>();

        ending.SetActive(false);
    }


    private void Start()
    {
        
    }

    void SearchForTarget()
    {
       
    }

    public void EnemyTurn()
    {
        StartCoroutine(Wait());
    }

    public void CheckEnding()
    {
        if (enemy.health.anim.enabled == false)
        {
            playerWon = false;
        }
        else
        {
            playerWon = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        foreach (var b in playerBtns)
            b.interactable = false;
        enemy.Attack();
        GameplayAudio.instance.PlayButtonSound();
        yield return new WaitForSeconds(1f);
        foreach (var b in playerBtns)
            b.interactable = true;
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
    }

    public void Quit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
