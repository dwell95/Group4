using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EdgeSculpt : MonoBehaviour
{
    [SerializeField]
    bool generate;
    [SerializeField]
    bool save;
    [SerializeField]
    string fileName;
    [SerializeField]
    int vertCount;
    Mesh mesh;
    [SerializeField]
    Vector3[] vertices;
    [SerializeField]
    Vector2[] uvs;
    [SerializeField]
    int[] lines;
    // Start is called before the first frame update
    void OnValidate()
    {
        if(generate)
        { 
            mesh = new Mesh();
            mesh.Clear();
            
            mesh.vertices = vertices;
            mesh.SetIndices(lines,MeshTopology.Lines,0,false);
            mesh.uv = uvs;
            //Bounds infBounds = new Bounds();
            //infBounds.extents = new Vector3(Mathf.Infinity,Mathf.Infinity,Mathf.Infinity);
            //mesh.bounds = infBounds;
            GetComponent<MeshFilter>().mesh = mesh;
        }

        if(save)
        {
            save = false;
            AssetDatabase.CreateAsset(mesh, "Assets/"+fileName+".asset");
        }
    }

    

    // Update is called once per frame
    
}
