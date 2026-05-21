using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyScript))]
public class MyScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        MyScript myscript = (MyScript)target;

        GUILayout.Label("Look at this button!");

        if (GUILayout.Button("Test")) Debug.Log("TEST");
    }

    void OnSceneGUI()
    {
        Handles.Label(Vector3.zero, "Hey look at this label");
    }
}

public class MyScript : MonoBehaviour
{

}
