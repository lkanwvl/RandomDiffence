using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] GameObject GreenMap;
    [SerializeField, Range(0,15)] int MapSizeX = 7;
    [SerializeField, Range(0,15)] int MapSizeZ = 7;
    
    private void Awake()
    {
        for(int o = 0; o < MapSizeZ; o++)
        {
            for(int i = 0; i < MapSizeX; i++)
            {
                Instantiate<GameObject>(GreenMap, new Vector3(i * 4, 0, -o * 4), Quaternion.identity);
            }
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
