using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class UpgradeManager : UdonSharpBehaviour
{
    public Swordsman swordsman;
    public Archer archer;
    public Mage mage;

    public void UpgradeSwordsmanHealth()
    {
        swordsman.UpgradeHealth(5);
    }

    public void UpgradeSwordsmanAttack()
    {
        swordsman.UpgradeAttack(5);
    }

    public void UpgradeArcherHealth()
    {
        archer.UpgradeHealth(5);
    }

    public void UpgradeArcherAttack()
    {
        archer.UpgradeAttack(5);
    }

    public void UpgradeMageHealth()
    {
        mage.UpgradeHealth(5);
    }

    public void UpgradeMageAttack()
    {
        mage.UpgradeAttack(5);
    }
}
