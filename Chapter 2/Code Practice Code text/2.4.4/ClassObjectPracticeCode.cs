using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassObjectPractice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate three different instances of the Fruit class, each representing a different type of fruit. 
        // Use the second constructor to set the name and color of each Fruit instance.
        // For each instance print the result of the ToString() method.

        Fruit apple = new Fruit(" Apple ", " red");
        Fruit dragonfruit = new Fruit(" Dragonfruit ", " magenta");
        Fruit lemon = new Fruit(" Lemon ", " yellow");

        print(apple.ToString());
        print(dragonfruit.ToString());
        print(lemon.ToString());
    }
}

/* Create a new class called fruit.
    The Fruit class should have the following data members:
    * string name
    * string color
    * A default constructor method with no parameters
    * A second constructor method with two string parameters: One to set the name and one to set the color of a new Fruit instance.
    * A method called ToString() which returns a string containing the name of the fruit and its color.
*/
public class Fruit
{
    string name;
    string color;

    public Fruit()
    {

    }
    public Fruit(string _name, string _color)
    {
        name = _name;
        color = _color;
    }
    public string ToString()
    {
        return color + name;
    }

}
