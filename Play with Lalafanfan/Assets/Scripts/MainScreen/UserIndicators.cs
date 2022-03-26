using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserIndicators : MonoBehaviour
{
    [SerializeField] private FoodSatiety _foodSatiety;
    [SerializeField] private UserMoney _money;

    public FoodSatiety Satiety => _foodSatiety;
    public UserMoney Money => _money;
}
