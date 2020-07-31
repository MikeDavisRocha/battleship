using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Singleton")]
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("References")]
    public Transform pivotToRestart;
    public GameObject ship;    

    [Header("Behaviour")]
    [HideInInspector] public float gameTime = 1;
    [HideInInspector] public bool endGame;


    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        if (Input.GetButton("Cancel") && endGame)
            RestatGame();

        if (!endGame && UIManager.Instance.currentTime >= 0)
            UIManager.Instance.UpdateTime();

        if (!endGame && UIManager.Instance.currentTime <= 0)
            WinGame();
    }


    public void EndGame()
    {
        endGame = true;
        SpawnManager.Instance.spawnAble = false;
        UIManager.Instance.ShowGameOverScreen(true);
        gameTime = 0;
    }

    public void WinGame()
    {
        endGame = true;
        SpawnManager.Instance.spawnAble = false;
        UIManager.Instance.ShowVictoryScreen(true);
        gameTime = 0;
    }

    void RestatGame()
    {
        endGame = false;
        ship.transform.position = new Vector3(pivotToRestart.position.x, ship.transform.position.y, pivotToRestart.position.z);
        ship.GetComponent<ShipController>().allStatus[ship.GetComponent<ShipController>().healthLevel - 1].health = 100;
        ship.GetComponent<ShipController>().EnebleMesh(true);
        SpawnManager.Instance.DestroyerAllEnemy();
        SpawnManager.Instance.spawnAble = true;
        UIManager.Instance.ShowGameOverScreen(false);
        UIManager.Instance.ShowVictoryScreen(false);
        UIManager.Instance.RestartTime();
        UIManager.Instance.ResetCoinUI();
        UIManager.Instance.ResetPlayerHealthUI(100);
        gameTime = 1;
    }
}
