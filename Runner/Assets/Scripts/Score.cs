using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text text;

    private void Update()
    {
        text.text = "Ñ÷¸ò:" + ((int)(player.position.z / 10)).ToString();
    }
}
