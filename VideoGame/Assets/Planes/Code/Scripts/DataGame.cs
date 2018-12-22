using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGame {

    #region Variables
    private static bool startGame;
    private static bool endGame;
    private static bool died;

    private static int score;
    private static int healt = 10;
    
    #endregion


    #region Properties
    public static bool StartGame
    {
        get
        {
            return startGame;
        }

        set
        {
            startGame = value;
        }
    }

    public static bool EndGame
    {
        get
        {
            return endGame;
        }

        set
        {
            endGame = value;
        }
    }

    public static bool Died
    {
        get
        {
            return died;
        }

        set
        {
            died = value;
        }
    }

    public static int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public static int Healt
    {
        get
        {
            return healt;
        }

        set
        {
            healt = value;
        }
    }
    #endregion



}
