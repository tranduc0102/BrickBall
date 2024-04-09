using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2Int size;
    public Vector2 offset;
    public GameObject boxPrefabs;
    public float x;
    private void Start()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newBox = Instantiate(boxPrefabs, transform);
                newBox.transform.position = transform.position + new Vector3((float)((size.x-1)*x-i) * offset.x, j * offset.y,0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.countBlock -= 1;
            Destroy(gameObject);
        }
    }
}
