using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEditor;


namespace MyTools
{
    public class B_ProjectSetup_window : EditorWindow
    {
        #region Variables
        static B_ProjectSetup_window win;

        private string gameName = "Game";
        #endregion

        #region Main Methods
        public static void InitWindow()
        {
            win = EditorWindow.GetWindow<B_ProjectSetup_window>("Project Setup");
            win.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            //EditorGUILayout.LabelField("Project Setup");
            gameName = EditorGUILayout.TextField("Game Name: ", gameName);
            EditorGUILayout.EndHorizontal();

            if(GUILayout.Button("Create Project Structure",GUILayout.Height(35), GUILayout.ExpandWidth(true)))
            {
                CreateProjectFolders();
            }
          

            if ( win != null)
            {
                win.Repaint();
            }
        }
        #endregion

        #region Custom Methods
        void CreateProjectFolders()
        {
            if (string.IsNullOrEmpty(gameName))
            {
                return;
            }

            if(gameName == "Game")
            {
                if(!EditorUtility.DisplayDialog("Project Setup Warning", "Do you really want to call your project Game?", "Yes", "No"))
                {
                    return;
                }
                
            }
            //Create subdirectories
            string assetPath = Application.dataPath;
            string rootPath = assetPath + "/" + gameName;

            DirectoryInfo rootInfo =  Directory.CreateDirectory(rootPath);

            

            if(!rootInfo.Exists)
            {
                return;
            }

            CreateSubFolders(rootPath);

            AssetDatabase.Refresh();
            CloseWindow();

        }

        void CreateSubFolders(string rootPath)
        {
            DirectoryInfo rootInfo = null;
            List<string> folderNames = new List<string>();

            rootInfo = Directory.CreateDirectory(rootPath + "/Art");

            if(rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Animation");
                folderNames.Add("Audio");
                folderNames.Add("Fonts");
                folderNames.Add("Materials");
                folderNames.Add("Models");
                folderNames.Add("Textures");
                folderNames.Add("Sprites");

                CreateFolders(rootPath + "/Art", folderNames);

            }

            rootInfo = Directory.CreateDirectory(rootPath + "/Code");

            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Editor");
                folderNames.Add("Scripts");
                folderNames.Add("Shaders");

                CreateFolders(rootPath + "/Code", folderNames);
            }

            rootInfo = Directory.CreateDirectory(rootPath + "/Resources");

            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Characters");
                folderNames.Add("UI");

                CreateFolders(rootPath + "/Resources", folderNames);

            }

            rootInfo = Directory.CreateDirectory(rootPath + "/Prefabs");

            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Characters");
                folderNames.Add("UI");

                CreateFolders(rootPath + "/Prefabs", folderNames);

            }

            //Create Scene
            DirectoryInfo sceneInfo = Directory.CreateDirectory(rootPath + "/Scenes");

            if(sceneInfo.Exists)
            {
                CreateScene(rootPath + "/Scenes", gameName + "_Main");
                CreateScene(rootPath + "/Scenes", gameName + "_FrontEnd");
                CreateScene(rootPath + "/Scenes", gameName + "_StarUp");

            }



        }

        void CreateFolders(string aPath, List<string> folders)
        {
            foreach(string folder in folders)
            {
                Directory.CreateDirectory(aPath+ "/" + folder);
            }
        }

        void CreateScene(string aPath, string name)
        {
            Scene curScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
            EditorSceneManager.SaveScene(curScene, aPath + "/" + name + ".unity", true);
            
        }

        void CloseWindow()
        {
            if (win)
            {
                win.Close();
            }
        }
        #endregion

    }

}

