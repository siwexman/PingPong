using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed;
    public float extraSpeedPerHit;
    public float maxSpeed;

    int hitCounter = 0;

    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    void PositionBall(bool isStartingPlayer1 = true)
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }


    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);

        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer1)
        {
            this.MoveBall(new Vector2(-1, 0));
        }
        else
        {
            this.MoveBall(new Vector2(1, 0));
        }
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;
        float speed = this.moveSpeed + this.hitCounter * this.extraSpeedPerHit;

        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = dir * speed;

    }

    public void IncreaseHitCounter()
    {
        if (this.hitCounter * this.extraSpeedPerHit <= this.maxSpeed)
        {
            this.hitCounter++;
        }
    }
}
