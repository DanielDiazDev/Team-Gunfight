using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionView : MonoBehaviour
{
    public static Action OnWeaponSelectedEvent;
    [SerializeField] private Button _weaponSelectedButton;
    [SerializeField] private GameObject _contentView;
    private void Start()
    {
        _weaponSelectedButton.onClick.AddListener(WeaponSelected);
    }

    void WeaponSelected()
    {
        var weaponIndex = 2;
        PlayerPrefs.SetInt("WeaponIndex", weaponIndex);
        OnWeaponSelectedEvent?.Invoke();
        _contentView.SetActive(false);
    }
}
