using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modificarterreno : MonoBehaviour {
    Terrain chao;
    BoxCollider box;
	// Use this for initialization
	void Start () {
        chao = Terrain.activeTerrain;
        box = GetComponent<BoxCollider>();
        Debug.Log(chao.terrainData.alphamapResolution);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
