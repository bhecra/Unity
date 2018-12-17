using UnityEngine;
using UnityEditor;

namespace MyTools
{
    public class EditorMenus
    {


        [MenuItem("MyTools/Project/Project Setup Tool")]
        public static void InitProjectSetupTool()
        {
            B_ProjectSetup_window.InitWindow();
        }
        [MenuItem("MyTools/Project/Scene Setup")]
        public static void InitSceneSetupTool()
        {
            B_SceneSetup_Windows.LaunchSetupWinows();
        }


    }
}
