using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : Shape
{

    protected override void Start()
    {
        base.Start();
        SetColor(Color.yellow);
        //playerSpeed = 10;
        //projectileSpeed = 2;
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement *= Time.deltaTime * gameSceneController.playerSpeed;
            horizontalMovement += transform.position.x;

            float right = gameSceneController.screenBounds.x - halfWidth;
            float left = -right;

            float limit = Mathf.Clamp(horizontalMovement, left, right);
            transform.position = new Vector2(limit, transform.position.y);
        }
    }

    private void FireProjectile()
    {
        Vector2 spawnPosition = transform.position;
        ProjectileController projectile = Instantiate(
            gameSceneController.projectilePrefab,
            spawnPosition,
            Quaternion.identity
        );

        projectile.projectileSpeed = gameSceneController.projectileSpeed;
        projectile.projectileDirection = Vector2.up;

    }
}