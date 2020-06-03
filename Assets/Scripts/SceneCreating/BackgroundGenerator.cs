using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public float WidthOfImage;
    private float X;

    private void OnBecameInvisible()
    {
        X = this.gameObject.transform.position.x + WidthOfImage * 2;
        gameObject.transform.position = new Vector3(X, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
