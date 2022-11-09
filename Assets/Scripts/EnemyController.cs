using System;
using UnityEngine;

public delegate void EnemyEscapedHandler(EnemyController enemy);
public class EnemyController : Shape, IKillable
{
    public event EnemyEscapedHandler EnemyEscaped;
    public event Action<int> EnemyKilled;

    protected override void Start()
    {
        base.Start();
        Name = "Enemy";
    }

    void Update()
    {
        MoveEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (EnemyKilled != null)
        {
            EnemyKilled(10);
            Destroy(collision.gameObject); // destroys the object colliding w this
            Destroy(gameObject);
        }
    }
    private void MoveEnemy()
    {
        transform.Translate(Vector2.down * Time.deltaTime * gameSceneController.enemySpeed, Space.World);

        float bottom = transform.position.y - halfHeight;
        if (bottom <= -gameSceneController.screenBounds.y)
        {
            EnemyEscaped?.Invoke(this);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public string GetName()
    {
        return Name;
    }
}
