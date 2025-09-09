using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car
{
    int wheels;
    string color;
    float speed;
    public float distance;

    public Car()
    {
        wheels = 4;
        color = "black";
        distance = 0.0f;
    }
    public Car(string _color, float _speed)
    {
        wheels = 4;
        color = _color;
        distance = 0.0f;
        speed = _speed;
    }

    public void Drive(float time)
    {
        distance += time * speed;
    }
    public void Brake()
    {

    }
}
public class Truck : Car
{

}

public class Classes : MonoBehaviour
{
    Car redCar = new Car("red", 5);
    Car blueCar = new Car("blue", 6);
    Truck yellowTruck = new Truck();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        redCar.Drive(Time.deltaTime);
        blueCar.Drive(Time.deltaTime);
        yellowTruck.Drive(Time.deltaTime);
        print("red car: " + redCar.distance);
        print("blue car: " + blueCar.distance);
    }
}
