
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateAttackAnimations : ScriptableWizard
{
    public string attackName = "New Attack";

    private string[] states = {"Anticipation", "Action", "Recovery"};
    private string[] directions = {"Up", "Left", "Right", "Down"};

    //
    // Unity Methods
    //

    private void Awake()
    {
        
    }

    //
    // Event Methods
    //

    // Create button click
    private void OnWizardCreate()
    {
        // Create primary folder
        string guid = AssetDatabase.CreateFolder(AssetDatabase.GetAssetPath (Selection.activeObject), attackName);
        string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);

        // Create all the subfolders required in a module
        foreach (string state in states)
        {
            string subGuid = AssetDatabase.CreateFolder(newFolderPath, state);
            string newSubFolderPath = AssetDatabase.GUIDToAssetPath(subGuid);
            
            foreach(string direction in directions)
            {
                AssetDatabase.CreateAsset(new AnimationClip(), newSubFolderPath + "/" + attackName + " " + state + " " + direction + ".anim");
            }
        }

        AssetDatabase.Refresh();
    }

    //
    // Public Methods
    //


    //
    // Private Methods
    //

    [MenuItem("Assets/Create/Attack Behavior Animations", false, 20)]
    private static void CreateWizard()
    {
        DisplayWizard("Attack Behavior Animations", typeof(CreateAttackAnimations), "Create");
    }
}

