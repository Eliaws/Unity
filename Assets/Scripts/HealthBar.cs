using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public Gradient gradient;

    public PlayerData playerData;
    public void Fill(float amountNormalized){
        bar.fillAmount = amountNormalized;
        //Change Health bar's color according to the gradient
        bar.color = gradient.Evaluate(amountNormalized);
 
    }

    private void Update(){
        Fill((float) playerData.currentLifePoints / (float) playerData.maxLifePoints);
    }
}
