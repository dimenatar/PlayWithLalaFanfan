using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] private ExperienceManager _experienceManager;

    private int _starCounter;

    public delegate void StarsUpdated(int current);
    public event StarsUpdated OnStarsUpdated;

    public int StarCounter 
    { 
        get => _starCounter; 
        private set
        {
            _starCounter = value;
            OnStarsUpdated?.Invoke(StarCounter);
        }
    }

    private void Awake()
    {
        _experienceManager.OnLevelChanged += (l) => AddStars();
    }

    public void Initialise(int stars)
    {
        _starCounter = stars;
    }

    public void AddStars (int stars = 1)
    {
        StarCounter += stars;
    }

    public bool SpendStars(int stars)
    {
        if (_starCounter >= stars)
        {
            _starCounter -= stars;
            return true;
        }
        return false;
    }
}
