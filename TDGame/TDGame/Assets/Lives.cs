﻿using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Text lives;

    private void Update()
    {
        lives.text = string.Format("LIVES:\n{0}", PlayerStats.lives);
    }
}
