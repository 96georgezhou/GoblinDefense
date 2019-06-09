using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTower : MonoBehaviour
{

    [SerializeField] private string name;
    [SerializeField] private GameObject priceText;
    private int price;

    void Start()
    {
        price = 1;
    }
    
    public void Upgrade() {

		if (StatusPanel.instance.DecreaseMoney (price)) {
			++price;
			priceText.GetComponent<Text> ().text = price.ToString ();
        

			if (this.name == "fire") {
				StaticVariable.fireTowerDamage += 5;
			} else if (this.name == "wind") {
				StaticVariable.windTowerDamage += 5;
			} else if (this.name == "earth") {
				StaticVariable.earthTowerDamage += 5;
			} else if (this.name == "water") {
				StaticVariable.waterTowerDamage += 5;
			} else if (this.name == "lightning") {
				StaticVariable.lightntowerDamage += 5;
			} else {
				Debug.Log ("name: lkdjfkaf lkdsf" + name);
			}
		}
    }
}
