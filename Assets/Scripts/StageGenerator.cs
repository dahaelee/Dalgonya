using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
	const int StageTipSize = 30;

	int currentTipIndex;

	public Transform character;
	public GameObject[] stageTips;
	public int startTipIndex;
	public int preInstantiate;
	public List<GameObject> generatedStageList = new List<GameObject>();

	void Start()
	{
		currentTipIndex = startTipIndex - 1;
		UpdateStage(preInstantiate);
	}

	void Update()
	{
		int charaPositionIndex = (int)(character.position.z / StageTipSize);

		if (charaPositionIndex + preInstantiate > currentTipIndex)
		{
			UpdateStage(charaPositionIndex + preInstantiate);
		}
	}

	void UpdateStage(int toTipIndex)
	{
		if (toTipIndex <= currentTipIndex)
			return;

		for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
		{
			GameObject stageObject = GenerateStage(i);

			generatedStageList.Add(stageObject);

			while (generatedStageList.Count > preInstantiate + 2)
				DestroyOldestStage();

			currentTipIndex = toTipIndex;
		}
	}

	GameObject GenerateStage(int tipIndex)
	{
		int nextStageTip = Random.Range(0, stageTips.Length);
		GameObject stageObject = (GameObject)Instantiate(stageTips[nextStageTip],
				 new Vector3(0, 0, tipIndex * StageTipSize), Quaternion.identity);

		return stageObject;
	}

	void DestroyOldestStage()
	{
		GameObject oldStage = generatedStageList[0];
		generatedStageList.RemoveAt(0);
		Destroy(oldStage);
	}
}
