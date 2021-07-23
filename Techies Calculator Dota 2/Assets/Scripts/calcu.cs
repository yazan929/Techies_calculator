using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.
using System;



public class calcu : MonoBehaviour
{

    public float qMines,uMines;// number of the mines needed
    public float proxDmg = 800; // basic proxDmg
    public float ultDmg = 300;  // basic dmg

    public float finalUltDmg = 0;
    public String hpText,magicText;
    public float finalProx,finalUlt; // stores the final dmg for ult and prox

    public float HeroHealth=0,HeroMagic=0; // stores magic RS AND Hp

    public TextMeshProUGUI totalQ,totalUlt;
    public TMP_InputField healthTextBox,magicTextBox;
    

    public Image level1,level2,level3,aghs; // images for all
    public bool checkL1,checkL2,checkL3,checkAghs;  // to know if a button is marked or not.

    public bool started;

    public bool tryHP,tryMG;


    void Awake() {
        HeroHealth= 600;
        HeroMagic = 25;


    }
    // Start is called before the first frame update
    void Start()
    {
        started = true;
        CalculateIT();
        checkAghs=false;
        checkL1=true;

    }
 void Update(){
   if (Input.GetKeyDown(KeyCode.Escape)){
        Application.Quit(); 
   
   } 
 }

public void addHP(){
    if(magicTextBox.text == ""){
        magicTextBox.text= "25";    
    }
    if(healthTextBox.text == ""){ // we don't need this no more
        healthTextBox.text= "100";
    }


    HeroHealth = float.Parse(healthTextBox.text);
    HeroHealth = HeroHealth + 100;
    healthTextBox.text = "" + HeroHealth;

    if(HeroHealth > 99999){
        healthTextBox.text = "99999";
    }   
}

public void minusHP(){
    if(magicTextBox.text == ""){
        magicTextBox.text= "25";    
    }
    if(healthTextBox.text == ""){
        healthTextBox.text= "0";
    }

    HeroHealth = float.Parse(healthTextBox.text);
    HeroHealth = HeroHealth - 100;
    healthTextBox.text = "" + HeroHealth;

    if(HeroHealth < 0){
        healthTextBox.text = "0";
    }
 

}

public void addMagic(){

    if(healthTextBox.text == ""){ // we don't need this no more
        healthTextBox.text= "600";
    }
    if(magicTextBox.text == ""){
        magicTextBox.text= "25";
    }


    HeroMagic = float.Parse(magicTextBox.text);
    HeroMagic = HeroMagic + 5;
    magicTextBox.text = "" + HeroMagic;

    if(HeroMagic > .99){
        magicTextBox.text= "99";
    }
    HeroMagic = float.Parse(magicTextBox.text);

}

public void minusMagic(){
    if(healthTextBox.text == ""){ // we don't need this no more
        healthTextBox.text= "600";
    }
    if(magicTextBox.text == ""){
        magicTextBox.text= "25";    
    }
    HeroMagic = float.Parse(magicTextBox.text);



    HeroMagic = HeroMagic - 5;

    magicTextBox.text = "" + HeroMagic;

    if(HeroMagic < .25){
        magicTextBox.text= "25";
    }
    
    HeroMagic = float.Parse(magicTextBox.text);

}

    public void CalculateIT(){

        if(started){
             healthTextBox.text = "600";
             magicTextBox.text = "25";
             started = false;
        }

        if(HeroHealth < 0){
        healthTextBox.text = "0";
    }
        if(healthTextBox.text == ""){
            HeroHealth = 0;
        }
        if(magicTextBox.text == ""){
            HeroMagic= 0;
        }

        HeroHealth = float.Parse(healthTextBox.text);
        HeroMagic = float.Parse(magicTextBox.text);
        HeroMagic = HeroMagic/100;

        finalUltDmg = ultDmg -  (ultDmg * HeroMagic);
        proxDmg = 800 - (800 * HeroMagic);

        uMines = HeroHealth / finalUltDmg;
        if(uMines - Mathf.Round(uMines) != 0){ // fix this later <3
        uMines++;
        }
        uMines = Mathf.Round(uMines);
        totalUlt.text = ""+ uMines;

        qMines = HeroHealth / proxDmg;
        if(qMines - Mathf.Round(qMines) != 0){ // fix this later <3
        qMines++;
        }
        qMines = Mathf.Round(qMines);
        totalQ.text = ""+ qMines;
    }


    

    public void clickLevel1(){
        checkL1=true;
        checkL2=false;
        checkL3=false;
        level1.color  = new Color(0.9137256f, 0.2901961f, 0.3764706f, 1f);
        level2.color =  new Color(0.6039216f, 0.7176471f, 0.5960785f, 1f);
        level3.color = new Color(0.6039216f, 0.7176471f, 0.5960785f, 1f);
            
            ultDmg=300;
            if(checkAghs){
                ultDmg = ultDmg + 150;
            }

        if(healthTextBox.text == ""){
            healthTextBox.text = "600";


        }
        if(magicTextBox.text == ""){
            magicTextBox.text= "25";
        }



CalculateIT();
    }
    public void clickLevel2(){
        checkL2=true;
        checkL1=false;
        checkL3=false;
        level2.color  = new Color(0.9137256f, 0.2901961f, 0.3764706f, 1f);
        level1.color =  new Color(0.6039216f, 0.7176471f, 0.5960785f, 1f);
        level3.color = new Color(0.6039216f, 0.7176471f, 0.5960785f, 1f);

            ultDmg=450;
            if(checkAghs){
                ultDmg = ultDmg + 150;
            }

        if(healthTextBox.text == ""){
            healthTextBox.text = "600";


        }
        if(magicTextBox.text == ""){
            magicTextBox.text= "25";
        }

CalculateIT();
    }

    public void clickLevel3(){
        checkL3=true;
        checkL1=false;
        checkL2=false;
        level3.color  = new Color(0.9137256f, 0.2901961f, 0.3764706f, 1f);
        level2.color =  new Color(0.6039216f, 0.7176471f, 0.5960785f, 1f);
        level1.color = new Color(0.6039216f, 0.7176471f, 0.5960785f, 1f);  
            
            
            
            ultDmg=600;
            if(checkAghs){
                ultDmg = ultDmg + 150;
            }

        if(healthTextBox.text == ""){
            healthTextBox.text = "600";


        }
        if(magicTextBox.text == ""){
            magicTextBox.text= "25";
        }


CalculateIT();
    }

    public void clickAghs(){

        if(checkAghs){
            checkAghs=false;
            aghs.color =  new Color(0.6039216f, 0.7176471f, 0.5960785f, 1f);
            ultDmg = ultDmg - 150;
            
        }
        else{
            checkAghs=true;
            aghs.color  = new Color(0.9137256f, 0.2901961f, 0.3764706f, 1f);
            ultDmg = ultDmg + 150;

        }
            
        if(healthTextBox.text == ""){
            healthTextBox.text = "600";


        }
        if(magicTextBox.text == ""){
            magicTextBox.text= "25";
        }
CalculateIT();
    }














}
