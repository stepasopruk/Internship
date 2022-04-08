using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SettingEditor : EditorWindow
{
    public static int StrenghtMultipl = 1;
    public static int AgilityMultipl = 1;
    public static int IntellectMultipl = 1;

    [MenuItem("Window/My Settings")]
    public static void ShowSettingEditor()
    {
        SettingEditor window = (SettingEditor)EditorWindow.GetWindow(typeof(SettingEditor));
        window.Show();
    }

    private void OnEnable()
    {
        StrenghtMultipl = PlayerPrefs.GetInt("StrenghtMultipl", StrenghtMultipl);
        AgilityMultipl = PlayerPrefs.GetInt("AgilityMultipl", AgilityMultipl);
        IntellectMultipl = PlayerPrefs.GetInt("IntellectMultipl", IntellectMultipl);

    }


    private void OnGUI()
    {
        int strenghtMultipl = EditorGUILayout.IntField("Strenght Multipl: ", StrenghtMultipl);
        int agilityMultipl = EditorGUILayout.IntField("Agility Multipl: ", AgilityMultipl);
        int intellectMultipl = EditorGUILayout.IntField("Intellect Multipl: ", IntellectMultipl);


        StrenghtMultipl = Save("StrenghtMultipl", strenghtMultipl, StrenghtMultipl);
        AgilityMultipl = Save("AgilityMultipl", agilityMultipl, AgilityMultipl);
        IntellectMultipl = Save("IntellectMultipl", intellectMultipl, IntellectMultipl);

    }

    public int Save(string key, int newValue, int oldValue)
    {
        if (newValue != oldValue)
        {
            PlayerPrefs.SetInt(key, newValue);
            return newValue;
        }

        return oldValue;
    }
}
