using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(UnitStatus))]
public class UnitStatusEditor : Editor
{
    public override void OnInspectorGUI()
    {
        UnitStatus unitStatus = (UnitStatus)target;

        var statusDictionary = unitStatus.StatusDictionary;

        if (statusDictionary != null)
        {
            foreach (var kvp in statusDictionary)
            {
                StatusType key = kvp.Key;
                StatusCount value = kvp.Value;

                float newValue = EditorGUILayout.FloatField(key.ToString(), value.Value);

                if (newValue != value.Value)
                {
                    value.Value = newValue;

                    EditorUtility.SetDirty(unitStatus);
                }
            }
        }
        else
        {
            EditorGUILayout.LabelField("Status Dictionary is null or empty.");
        }
    }
}
