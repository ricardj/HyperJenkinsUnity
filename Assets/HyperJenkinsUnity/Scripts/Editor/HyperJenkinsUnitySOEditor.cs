using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HyperJenkinsUnitySO))]
public class HyperJenkinsUnitySOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Trigger Build"))
        {
            HyperJenkinsUnitySO jenkins = (HyperJenkinsUnitySO)target;
            jenkins.StartBuild();
        }
    }


    [MenuItem("Tools/Start Build")]
    public static void StartBuild()
    {
        HyperJenkinsUnitySO.get.StartBuild();
    }
}