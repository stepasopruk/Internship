using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HealthHelper))]
public class HealthHelperEditor : Editor
{
    public Texture2D StrenghtTexsture2D;
    public Texture2D AgilityTexsture2D;
    public Texture2D IntellectTexsture2D;
    public Texture2D MaxHealthTexsture2D;
    public Texture2D ConstHealthTexsture2D;
    public Texture2D HealthTexsture2D;

    public SerializedProperty ConstHealth;
    public SerializedProperty MaxHealth;
    public SerializedProperty Health;

    public SerializedProperty isHero;
    public SerializedProperty Strenght;
    public SerializedProperty Agility;
    public SerializedProperty Intellect;

    public SerializedProperty Group;

    private void OnEnable()
    {
        ConstHealth = serializedObject.FindProperty("ConstHealth");
        MaxHealth = serializedObject.FindProperty("MaxHealth");
        Health = serializedObject.FindProperty("Health");

        isHero = serializedObject.FindProperty("isHero");
        Strenght = serializedObject.FindProperty("Strenght");
        Agility = serializedObject.FindProperty("Agility");
        Intellect = serializedObject.FindProperty("Intellect");

        Group = serializedObject.FindProperty("Group");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        HealthHelper t = target as HealthHelper;

        if (!t)
            return;

        serializedObject.Update();

        Characteristic(ConstHealth, "Const Health: ", ConstHealthTexsture2D);


        GUIStyle style = new GUIStyle(EditorStyles.label);

        style.normal.textColor = Color.red;
        style.margin = new RectOffset(0, 0, 10, 0);




        isHero.boolValue = EditorGUILayout.Toggle("Is Hero:", isHero.boolValue);

        if (isHero.boolValue)
        {
           

            Characteristic(Strenght, "Strenght: ", StrenghtTexsture2D);
            Characteristic(Agility, "Agility: ", AgilityTexsture2D);
            Characteristic(Intellect, "Intellect: ", IntellectTexsture2D);


            MaxHealth.intValue = Strenght.intValue * SettingEditor.StrenghtMultipl + ConstHealth.intValue;
        }
        else
            MaxHealth.intValue = ConstHealth.intValue;

        Characteristic(Health, "Health: ", HealthTexsture2D);

        GUILayout.BeginHorizontal();
        GUILayout.Label(MaxHealthTexsture2D, GUILayout.Width(40));
        GUILayout.Label("MaxHealth: " + t.MaxHealth.ToString(), style);
        GUILayout.EndHorizontal();

        if (Health.intValue > MaxHealth.intValue)
            Health.intValue = MaxHealth.intValue;

        Group.intValue = Mathf.Abs(EditorGUILayout.IntField("Group: ", Group.intValue));

        serializedObject.ApplyModifiedProperties();
    }

    void Characteristic(SerializedProperty property, string lable, Texture2D texture)
    {
        GUIStyle heroStyle = new GUIStyle(EditorStyles.textField);
        heroStyle.margin = new RectOffset(0, 0, 10, 0);

        GUILayout.BeginHorizontal();
        GUILayout.Label(texture, GUILayout.Width(40));
        property.intValue = Mathf.Abs(EditorGUILayout.IntField(lable, property.intValue, heroStyle));
        GUILayout.EndHorizontal();
    }

}
