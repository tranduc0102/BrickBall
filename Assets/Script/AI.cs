using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.UIElements;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Ball A;
    private float speed = 10f;
    private float delayTime = 0.5f; // Thời gian delay (2 giây)
    private bool isDelayed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDelayed)
        {
            // Giảm thời gian đợi xuống
            delayTime -= Time.deltaTime;

            // Nếu thời gian đợi đã kết thúc
            if (delayTime <= 0)
            {
                if ((transform.position.x > A.transform.position.x && A.transform.position.x > 0) || (transform.position.x > A.transform.position.x && A.transform.position.x < 0) )
                { 
                    rb.velocity = new Vector2(-speed , transform.position.y);
                }
                else
                {
                    rb.velocity = new Vector2(speed , transform.position.y);
                }
                // Thực hiện hành động sau khi delay
                Debug.Log("Delay finished!");
                // Reset biến và thời gian delay
                isDelayed = false;
                delayTime = 0.5f; // Đặt lại thời gian delay
            }
        }
        else
        {
            // Thực hiện hành động trước khi delay
            Debug.Log("Before delay");
            // Bắt đầu delay bằng cách đặt isDelayed thành true
            isDelayed = true;
        }
        
        
        /*if ((transform.position.x < A.transform.position.x && transform.position.x > 0) || (transform.position.x < A.transform.position.x && transform.position.x < 0) )
        {
            rb.velocity = new Vector2(speed , transform.position.y);
        }*/
        
    }
}
