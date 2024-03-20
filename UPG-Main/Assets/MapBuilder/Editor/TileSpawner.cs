using UnityEditor;
using UnityEngine;

public class TileSpawner : EditorWindow
{
    GameObject spawnObj;
    int Objectid = 1;
    bool spawnMode;
    float zCoord = 0;

    [MenuItem("Tools/MapBuilder")]
    public static void showWindow()
    {
        GetWindow<TileSpawner>();
    }

    private void OnGUI()
    {
        GUILayout.Label("Start building a map", EditorStyles.boldLabel);
        spawnObj = EditorGUILayout.ObjectField("thing to spawn", spawnObj, typeof(GameObject), true) as GameObject;
        zCoord = EditorGUILayout.FloatField("Z coordinate", 0);
        spawnMode = GUILayout.Toggle(spawnMode, "Spawn Mode");

        if (spawnMode)
        {
            Event e = Event.current;
            if (e.type == EventType.MouseDown)
            {
                SpawnObject();
            }
        }
    }

    private void SpawnObject()
    {

        onClick();
        Debug.Log("worked! id=" + Objectid);
        Objectid++;
    }

    private void onClick()
    {
        
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

            Vector3 blockPos = ray.origin;

            Instantiate(spawnObj, blockPos, Quaternion.identity);

    }
}
