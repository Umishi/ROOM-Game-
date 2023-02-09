using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�v���[���[���w��
    public GameObject Player;

    //���x
    [SerializeField] float Speed;

    //����
    private Rigidbody2D rb = null;

    //�A�j���[�V����
    private Animator Animation = null;


    // Start is called before the first frame update
    void Start()
    {
        //�����A�A�j���[�V����������Ă���
        rb = Player.GetComponent<Rigidbody2D>();
        Animation = Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        Move();
    
    
    }

    void Move()
    {
        float CharaSpeed=0.0f;
        float HorizontalKey = Input.GetAxisRaw("Horizontal");

        if (HorizontalKey < 0)
        {

            Animation.SetBool("PlayerRun", true);
            Player.transform.localScale = new Vector3(-0.6f, 0.6f, 1);
            CharaSpeed = -Speed;

        }

        else if (HorizontalKey > 0)
        {
            Animation.SetBool("PlayerRun", true);
            Player.transform.localScale = new Vector3(0.6f, 0.6f, 1);
            CharaSpeed = Speed;

        }

        else 
        {
            Animation.SetBool("PlayerRun", false);


        }
        rb.velocity = new Vector2(CharaSpeed, rb.velocity.y);

    }



}
