using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public static class PlayerGoingBack
{
    public static bool isGoingBack = false;
}
public class PlayerMovement : MonoBehaviour
{
    [Header("Player controls")]
    [SerializeField]
    private float speed = 0.2f;

    [SerializeField]
    [Range(0.1f,5f)]
    private float HeightOfJump = 1f;
 
    [SerializeField]
    public Animator animator;
    //for jump sound 
    float lastTimePlayed=0;
    int temp = 0;
    void Update()
    {
        if(!PauseMenu.isGamePaused)
        {
            temp++;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (PlayerGoingBack.isGoingBack)
                {
                    transform.Translate(-Vector2.right * speed * Time.deltaTime);
                    transform.Rotate(0, 180f, 0);
                }
                else
                {
                    transform.Translate(Vector2.right.normalized * speed * Time.deltaTime);
                }
                PlayerGoingBack.isGoingBack = false;
                animator.SetFloat("Speed", math.abs(speed));
            }

            if (Input.GetKey(KeyCode.LeftArrow) && !CameraLimit.isLeftLimitReached)
            {
                if (!PlayerGoingBack.isGoingBack)
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                    transform.Rotate(0, 180f, 0);
                }
                else
                    transform.Translate(-Vector2.left * speed * Time.deltaTime);

                animator.SetFloat("Speed", math.abs(speed));
                PlayerGoingBack.isGoingBack = true;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector2(0, HeightOfJump) * speed * Time.deltaTime);
                animator.SetBool("IsJumping", true);

                if(lastTimePlayed+2<=temp)
                    FindObjectOfType<AudioManager>().Play("jumpSound");
                lastTimePlayed=temp;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                animator.SetBool("IsJumping", false);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                animator.SetFloat("Speed", 0);
            }
            if (this.gameObject.transform.position.y < -10)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
        }
        
    }
}
