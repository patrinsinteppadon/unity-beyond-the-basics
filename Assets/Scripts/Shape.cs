using UnityEngine;

public class Shape : MonoBehaviour
{
    public string Name;
    protected GameSceneController gameSceneController;
    protected float halfWidth;
    protected float halfHeight;
    private SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        gameSceneController = FindObjectOfType<GameSceneController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        halfWidth = spriteRenderer.bounds.extents.x;
        halfWidth = spriteRenderer.bounds.extents.y;
    }
    public void SetColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
    public void SetColor(float red, float green, float blue)
    {
        spriteRenderer.color = new Color(red, green, blue);
    }
}
