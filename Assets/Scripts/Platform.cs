using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    public GameObject paddle;
    public bool autoplay = false;
    public GameObject ball;
    public float minX, maxX,speed;
    private float stop = 0f;
    public bool right, left, down;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) right = true; else right = false;
        if (Input.GetKey(KeyCode.LeftArrow)) left = true; else left = false;

        if (!autoplay)
        {
            Debug.Log(paddle.transform.position);
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (paddle.transform.position.x < minX)
                {
                    Debug.Log("DETENER");
                    paddle.transform.Translate(Vector3.left * stop * Time.deltaTime);
                }
                else paddle.transform.Translate(Vector3.left * speed  * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (paddle.transform.position.x > maxX)
                {
                    Debug.Log("DETENER");
                    paddle.transform.Translate(Vector3.right * stop * Time.deltaTime);
                }
                else paddle.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

        }
        else
        {
            if (right)
            {
                Vector3 paddlePos = this.transform.position;
                Vector3 ballPos = ball.transform.position;
                paddlePos.x = Mathf.Clamp(ballPos.x+.5f, minX, maxX);
                this.transform.position = paddlePos;
            }
            if (left)
            {
                Vector3 paddlePos = this.transform.position;
                Vector3 ballPos = ball.transform.position;
                paddlePos.x = Mathf.Clamp(ballPos.x-.5f, minX, maxX);
                this.transform.position = paddlePos;
            }
            if (!right&& !left)
            {
                Vector3 paddlePos = this.transform.position;
                Vector3 ballPos = ball.transform.position;
                paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
                this.transform.position = paddlePos;
            }
        }
    }
}