using UnityEngine;
using UnityEditor;
using System.IO;
using LuaFramework;

public class LuaTool : EditorWindow
{
    //lua文件路径
    string luaFilePath ="";

    [MenuItem("LuaTool/DoFile", false, 102)]
    static void DoIt()
    {
        LuaTool lua = GetWindow<LuaTool>();
        lua.Show();
    }

    private void OnGUI()
    {
        luaFilePath = EditorGUILayout.TextField("输入要执行的lua文件路径:", luaFilePath);
        if (GUILayout.Button("DoFile"))
        {
            DoLuaFile();
        }
    }


    private void DoLuaFile()
    {
        if(luaFilePath.Length == 0)
        {
            EditorGUILayout.HelpBox("文件路径错误", MessageType.None);
            return;
        }

        if (!File.Exists(luaFilePath))
        {
          EditorGUILayout.HelpBox("文件不存在", MessageType.None);
          return;
        }

        LuaManager mgr = AppFacade.Instance.GetManager<LuaManager>(ManagerName.Lua);
        mgr.DoFile(luaFilePath);
    }
}