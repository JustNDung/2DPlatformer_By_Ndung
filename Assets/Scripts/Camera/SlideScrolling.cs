using UnityEngine;

public class SlideScrolling : MonoBehaviour
{
    private Transform player;
    public float height = 2f;
    public float undergroundHeight = -24f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.x = player.position.x;
        transform.position = cameraPos;
    }

    public void SetUnderground(bool underground)
    {
        Vector3 cameraPos = transform.position;
        cameraPos.y = underground ? undergroundHeight : height;
        transform.position = cameraPos;
    }
    
}