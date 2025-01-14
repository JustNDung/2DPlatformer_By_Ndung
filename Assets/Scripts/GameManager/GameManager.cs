using UnityEngine;
using UnityEngine.SceneManagement; // Import để quản lý Scene

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 

    public PlayerController playerController; // Tham chiếu tới Player
    [SerializeField] private float playerHP = 100f; // HP ban đầu của Player

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
        if (playerController.currentHP <= 0)
        {
            playerController.Death();
        }
    }

    private void InitializePlayer()
    {
        if (playerController != null)
        {
            playerController.SetInitialHP(playerHP);
        }
        else
        {
            Debug.LogError("Player reference is missing in GameManager!");
        }
    }
 
    public void OnPlayerDeath()
    {
        
        Debug.Log("Player has died. Resetting Scene...");
        Invoke("ResetScene", 2f); // Gọi reset Scene sau 2 giây
    }

    private void ResetScene()
    {
        playerHP = 100f; // Reset HP
        InitializePlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại Scene hiện tại
    }
}
