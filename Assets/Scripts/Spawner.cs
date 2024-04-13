using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject pipePrefab;
	public float spawnRate = 1f;
	public float minHeight = -1f;
	public float maxHeight = 1f;

	private void OnEnable(){
		InvokeRepeating("Spawn", spawnRate, spawnRate);
	}

	private void OnDisable(){
		CancelInvoke("Spawn");
	}

	private void Spawn(){
		GameObject pipes = Instantiate(pipePrefab, transform.position, Quaternion.identity);
		pipes.transform.position = pipes.transform.position + Vector3.up * Random.Range(minHeight, maxHeight);
	}
}
