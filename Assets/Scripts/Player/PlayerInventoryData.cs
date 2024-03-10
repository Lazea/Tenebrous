using UnityEngine;

[CreateAssetMenu(
    fileName = "SO_Data_PlayerInventory",
    menuName = "Scriptable Objects/Player Inventory Data")]
public class PlayerInventoryData : ScriptableObject
{
    [Header("Resources")]
    public int ironResourceCount;
    public int quartzResourceCount;
    public int goldResourceCount;
    public int diamondResourceCount;

    [Header("Tools")]
    public bool drillUnlocked = true;
    public int drillbitLevel = 1;
    public bool blowTorchUnlocked = true;
    public bool harpoonGunUnlocked = false;
    public bool explosiveUnlocked = false;

    public void ResetData()
    {
        ironResourceCount = 0;
        quartzResourceCount = 0;
        goldResourceCount = 0;
        diamondResourceCount = 0;

        drillUnlocked = false;
        drillbitLevel = 1;
        blowTorchUnlocked = false;
        harpoonGunUnlocked = false;
        explosiveUnlocked = false;
    }
}