using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class LevelGenerator : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private List<Transform> levelPartList;
    [SerializeField]
    private Transform levelPart_Start;
    [SerializeField]
    private Transform player;
#pragma warning restore 0649
    [SerializeField]
    [Range(0, 200f)]
    private float playerDistance = 5f;

    private Vector3 lastEndPosition;
    public Transform LevelContainer;
    int brojac = 0;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        for (int i = 0; i < 5; i++)
        {
            GenerateNewLevelPart();
        }
    }

    private void GenerateNewLevelPart()
    {
        int randomLevelNumber = UnityEngine.Random.Range(0, levelPartList.Count);

        Transform lastLevelGenerated = Instantiate(levelPartList[randomLevelNumber], lastEndPosition, Quaternion.identity,LevelContainer);
        
        lastEndPosition = lastLevelGenerated.Find("EndPosition").position;
    }
    void Update()
    {
        if (Vector3.Distance(player.position, lastEndPosition) < playerDistance)
        {
            GenerateNewLevelPart();
        }
        if (player.position.x-LevelContainer.GetChild(brojac).Find("EndPosition").position.x>playerDistance)
        {
             Destroy(LevelContainer.GetChild(brojac).gameObject);
            if (brojac == 2)
                brojac = 0;
            else
                brojac++;
        }
    }
}
