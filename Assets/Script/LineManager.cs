
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] List<Transform> listLineCornor;//0 => 1 => 2 => 3 =>0
    public static LineManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Transform GetNextTarget(Transform _CurrentTarget)
    {
        int index = listLineCornor.IndexOf(_CurrentTarget) + 1;//현재 목표였던 위치는 몇번이었는지
        if (index >= listLineCornor.Count)
        {
            index = 0;
        }
        return listLineCornor[index];
    }

    public Transform GetFirstTarget()
    {
        return listLineCornor[0];
    }
}
