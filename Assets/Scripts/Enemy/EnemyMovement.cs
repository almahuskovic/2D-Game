using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    [Range(0,5f)]
    private float speed;
#pragma warning restore 0649

    public float sizeOfGround = 2f;
    float beggingPosition;
    float endPosition;
    bool isBegining = true;
    void Start()
    {
        beggingPosition = this.gameObject.transform.position.x;
        endPosition = beggingPosition + sizeOfGround;
    }

    void Update()
    {
        
        if (endPosition >= this.gameObject.transform.position.x && isBegining)
        {
            this.transform.Translate(speed * Time.deltaTime * Vector2.right);
        }
        
        else
        {
            isBegining = false;
            if (beggingPosition <= this.gameObject.transform.position.x)
            {
                this.transform.Translate(speed * Time.deltaTime * Vector2.left);
            }
             if (gameObject.transform.position.x <= beggingPosition)
                  isBegining = true;
        }
       
    }
}
