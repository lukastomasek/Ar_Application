using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] Button[] playerBtns;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    public GameObject ending;
    public TMPro.TextMeshProUGUI winTxt;

    [HideInInspector] public bool playerWon = false;

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
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (ending.gameObject.activeInHierarchy)
        {
            CheckEnding();
        }
    }

    public void EnemyTurn()
    {
        StartCoroutine(Wait());
    }

    public void CheckEnding()
    {
        if (enemy.isDead)
        {
            winTxt.text = "YOU WON !";
            winTxt.color = Color.green;
        }
        else
        {

            winTxt.text = "YOU LOSE !";
            winTxt.color = Color.red;

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
