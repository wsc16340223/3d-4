using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskInfo
{
    private Color color;
    private float scale;

    public void processDisk(GameObject _disk)
    {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        _disk.GetComponent<Renderer>().material.color = color;
        // 初始化color

        scale = Random.Range(2f, 2.5f);
        _disk.transform.localScale *= scale;
        // 初始化大小
    }
    public void processDisk(GameObject _disk, Color _color, float _scale)
    {
        _disk.GetComponent<Renderer>().material.color = _color;
        _disk.transform.localScale *= _scale;
        // 自己设置color和大小
    }
}