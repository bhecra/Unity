using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class B_SceneSetup_Windows : EditorWindow {

    #region Variables
    #endregion

    #region Builtin Methods

    public static void LaunchSetupWinows()
    {
        GetWindow(typeof(B_SceneSetup_Windows), true, "SceneSetup").Show();
    }

    void OnGUI()
    {
        if (GUILayout.Button("Create new StupScene"))
        {
            BuiltDefalutSetup();
            GetWindow<B_SceneSetup_Windows>().Close();
        }
    }
    #endregion



    #region

    public void BuiltDefalutSetup()
    {
        //Create the root GO
        GameObject item1 = new GameObject("Level_GRP");
        GameObject item2 = new GameObject("Game_Manager");
        GameObject item3 = new GameObject("Colliders_GRP");
        GameObject item4 = new GameObject("Ligths");
        GameObject item5 = new GameObject("Player");

    }
    #endregion


}
