using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public event Action OnPlayerHitStageTrigger;

    [SerializeField] private List<GameObject> _startStages;
    [SerializeField] private float _stageOffes;

    private List<GameObject> _currentStages;

    private void Awake()
    {
        OnPlayerHitStageTrigger += DeletePreviousStage;
        OnPlayerHitStageTrigger += SpawnNextStage;
    }

    private void Start()
    {
        _currentStages = _startStages;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stage trigger")
        {
            OnPlayerHitStageTrigger?.Invoke();
        }
    }

    private void DeletePreviousStage()
    {
        GameObject stage = _currentStages[0];
        Destroy(stage);
        _currentStages.Remove(stage);
    }

    private void SpawnNextStage()
    {
        GameObject stage = Instantiate(_currentStages[0], new Vector3(0, 0, _currentStages[_currentStages.Count-1].transform.position.z + _stageOffes), Quaternion.identity);
        _currentStages.Add(stage);
    }
}
