using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController
{
    
    static public LevelController shared = new LevelController();

    public int score = 0;
    public int lives = 3;

    private LevelController() { }

}
