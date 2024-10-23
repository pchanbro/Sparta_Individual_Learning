using System;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboardC : MonoBehaviour
{
    [SerializeField] private EnergySystemC energySystem;
    [SerializeField] private Image fillBar;

    private void Start()
    {
        // 에너지시스템의 에너지 사용에 대해 fillBar가 변경되도록 수정
        // delegate 활용 해보는 연습
        energySystem.OnEnergyChanged += UpdateFillBar;
    }

    private void UpdateFillBar(float currentFuel)
    {
        fillBar.fillAmount = currentFuel * 0.1f;
    }
}