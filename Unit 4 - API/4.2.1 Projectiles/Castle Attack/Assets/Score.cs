using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Animator scoreAnimator;
    public Text scoreDisplay;
    public int threeStars = 3;
    public int twoStars = 4;
    public int nextLevel = 0;

    public void EndLevel()
    {
        Cannon cannon = FindObjectOfType<Cannon>();
        if (cannon)
        {
            int numProjectiles = cannon.numProjectiles;
            if (numProjectiles < threeStars)
            {
                print("Three stars!");
                scoreDisplay.text = "Three stars!";
                scoreAnimator.SetInteger("Stars", 3);
            }
            else if (numProjectiles < twoStars)
            {
                print("Two stars");
                scoreDisplay.text = "Two stars!";
                scoreAnimator.SetInteger("Stars", 2);
            }
            else 
            {
                print("One star!");
                scoreDisplay.text = "One star!";
                scoreAnimator.SetInteger("Stars", 1);
            }
            Invoke("NextLevel", 2);
        }
        //Invoke("LoadThirdLevel", 2);
    }
    void NextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextLevel + 1); 
    }
    /*public void LoadThirdLevel()
    {
        SceneManager.LoadScene(nextLevel + 1);
    }
    */
}
