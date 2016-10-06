using UnityEditor;
using UnityEngine;

public class DeletePlayerPrefsEditor
{
    [MenuItem("Edit/Reset Playerprefs")]
    public static void DeletePlayerPrefs() { PlayerPrefs.DeleteAll(); }
}