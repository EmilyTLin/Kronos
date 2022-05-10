using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
    }
}
