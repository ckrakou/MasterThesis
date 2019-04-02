using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class KeyRemoverGUI : MonoBehaviour
{
    [CustomEditor(typeof(KeyRemover))]
    public class ObjectBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            KeyRemover myScript = (KeyRemover)target;
            if (GUILayout.Button("Remove Key"))
            {
                myScript.RemoveKey();
            }
        }
    }
}
