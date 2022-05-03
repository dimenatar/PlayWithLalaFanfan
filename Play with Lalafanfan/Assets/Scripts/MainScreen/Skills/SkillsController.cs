using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsController : MonoBehaviour
{
    private Skills _skills;

    public int GetCoins(int amount) => _skills.CoinModifier * amount;
    public float GetFoodSatiety(float satiety) => _skills.FoodModifier * satiety;
    public float GetGrowEnergy(float energy) => _skills.AddEnergyModifier * energy;
    public float GetReducedEnergy(float energy) => _skills.ReduceEnergyModifier * energy;
    public float GetBoringness(float boringness) => _skills.BoringnessGrowModifier * boringness;
}
