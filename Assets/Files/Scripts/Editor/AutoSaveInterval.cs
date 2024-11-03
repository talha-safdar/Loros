using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class AutoSaveInterval : EditorWindow
{
	// Save interval in minutes
	private static float saveIntervalMinutes = 5f;

	// Timer to track time between saves
	private static float nextSaveTime;

	// Editor window to configure the auto-save interval
	[MenuItem("Window/Auto Save Settings")]
	public static void ShowWindow()
	{
		GetWindow(typeof(AutoSaveInterval), false, "Auto Save Settings");
	}

	// Called when the window is drawn in the Editor
	private void OnGUI()
	{
		GUILayout.Label("Auto Save Settings", EditorStyles.boldLabel);

		// Input field to adjust the auto-save interval (in minutes)
		saveIntervalMinutes = EditorGUILayout.FloatField("Save Interval (minutes):", saveIntervalMinutes);

		// Button to force save the project and scene immediately
		if (GUILayout.Button("Force Save Now"))
		{
			SaveProjectAndScene();
		}
	}

	// Static constructor called when the Unity Editor loads
	static AutoSaveInterval()
	{
		// Editor update delegate to track time
		EditorApplication.update += Update;
		ResetTimer();
	}

	// Called once per frame in the Unity Editor
	static void Update()
	{
		if (EditorApplication.timeSinceStartup > nextSaveTime)
		{
			SaveProjectAndScene();
			ResetTimer();
		}
	}

	// Resets the save timer based on the interval
	private static void ResetTimer()
	{
		nextSaveTime = (float)EditorApplication.timeSinceStartup + saveIntervalMinutes * 60f;
	}

	// Saves the active scene and the entire project (assets)
	private static void SaveProjectAndScene()
	{
		Debug.Log("Auto-saving scene and project...");

		// Save the currently open scene
		EditorApplication.ExecuteMenuItem("File/Save");  // This saves the active scene.

		// Save the project assets
		AssetDatabase.SaveAssets();  // This saves all project assets.

		Debug.Log("Auto-save completed at " + System.DateTime.Now);
	}
}
