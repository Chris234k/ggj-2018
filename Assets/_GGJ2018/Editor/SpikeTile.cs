using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpikeTile : Tile
{
    Collider tileCollider;
    void Start()
    {
        tileCollider = gameObject.GetComponent<Collider>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);

        }
    }


#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/RoadTile")]
    public static void CreateRoadTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Spike Tile", "New Spike Tile", "Asset", "Save Spike Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SpikeTile>(), path);
    }
#endif
}
