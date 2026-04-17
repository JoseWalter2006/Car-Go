using UnityEngine;

public class Player : MonoBehaviour
{
    Gun[] guns;

    float moveSpeed = 5;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool speedDown;
    bool shoot;


    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
    }

    void Update()
{
    moveUp = Input.GetKey(KeyCode.UpArrow);
    moveDown = Input.GetKey(KeyCode.DownArrow);
    moveLeft = Input.GetKey(KeyCode.LeftArrow);
    moveRight = Input.GetKey(KeyCode.RightArrow);
    speedDown = Input.GetKey(KeyCode.LeftShift);
    shoot = Input.GetKeyDown(KeyCode.Z);
     if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                if (gun.gameObject.activeSelf)
                {
                    gun.Shoot();
                }
            }
        }
}

   private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        if (speedDown)
        {
            moveAmount /= 1.5f;
        }
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move;
        if (pos.x <= -6.24f)
        {
            pos.x = -6.24f;
        }
        if (pos.x >= 5.45f)
        {
            pos.x = 5.45f;
        }
        if (pos.y <= -0.31f)
        {
            pos.y = -0.31f;
        }
        if (pos.y >= 7.48f)
        {
            pos.y = 7.48f;
        }
        transform.position = pos;
    }
}