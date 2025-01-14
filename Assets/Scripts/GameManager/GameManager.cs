using UnityEngine;
using UnityEngine.SceneManagement; // Import để quản lý Scene
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 

    public PlayerController playerController; // Tham chiếu tới Player
    [SerializeField] private float playerHP = 100f; // HP ban đầu của Player
    private bool isSceneResetting = false; // Prevent multiple resets

    private void Awake()
    {
        // Đảm bảo chỉ có một GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không phá hủy khi chuyển Scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializePlayer();
    }

    private void Update()
    {
        if (!isSceneResetting && playerController.currentHP <= 0)
        {
            isSceneResetting = true;
            playerController.Death();
        }
    }

    public void InitializePlayer()
    {
        if (playerController != null)
        {
            playerController.SetInitialHP(playerHP);
        }
        else
        {
            Debug.LogError("Player reference is missing in GameManager!");
            ReacquirePlayerReference();
        }
    }
 
    public void OnPlayerDeath()
    {
        
        Debug.Log("Player has died. Resetting Scene...");
        StartCoroutine(ResetSceneAfterDelay(2f));
    }
    private IEnumerator ResetSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetScene();
    }

    private void ResetScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại Scene hiện tại
        SceneManager.sceneLoaded += OnSceneReloadComplete;
    }

    private void ReacquirePlayerReference()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        if (playerController != null)
        {
            playerController.SetInitialHP(playerHP);
            Debug.Log("Player reference reacquired and HP reset.");
        }
        else
        {
            Debug.LogError("Player reference could not be reacquired!");
        }
    }


    private void OnSceneReloadComplete(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneReloadComplete;
        isSceneResetting = false;
        ReacquirePlayerReference();
        Debug.Log("Scene reset complete and player reinitialized.");
    }
}
