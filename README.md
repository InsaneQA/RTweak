# Introduction
RTweak is a reflection-based tool that allows you to randomize values stored inside the object during the object creation. It can then be re-randomized at any point in time without even thinking about Random class.
### Key features:
- Supports all numeric value types (int, long, sbyte etc.)
- Works with Properties and Fields that have public or private access modifier
- Works well with Unity MonoBehaviour classes
- Allows you to invoke CleanUp methods if you use the Object Pool patterns

# Example
Here is our Monster class (Unity):
```csharp
    public class Monster : MonoBehaviour
    {
        [TweakRange(1, 5)] public int Strength { get; private set; }
        [TweakRange(1, 5)] public int Intelligence { get; private set; }
        [TweakRange(1, 5)] public int Charisma { get; private set; }

        [TweakTrue(0.9)] private bool WillChasePlayer;
        [TweakTrue] private bool isLucky;

        public void Awake()
        {
            TweakInjector.Inject(this);
        }
    }
```

### TweakRange
Getting random Strength, Intelligence and Charisma is possible by using the <b>TweakRange</b> attribute. You need to specify the maximum and the minimum values in the brackets, and use the ```TweakInjector.Inject(this);``` line anywhere in the code (including the constructor).  The generated value will be between 1 and 5, <b>including both 1 and 5.</b> (in the Random class, the maximum integer value *is not included*).
### TweakTrue
<b>TweakTrue</b> attribute allows you to generate a boolean value with a certain chance. ```[TweakTrue(0.9)]``` means that WillChasePlayer field has 90% chance to be true. isLucky field, however, has the default 50%, since no probability value is specified.
###TweakInjector.Inject
Finally, you need to invoke  ```TweakInjector.Inject(this)```  to pass the instance to the static class TweakInjector. All the fields and properties marked with the Tweak attributes will be injected.

#Tricky Example
Here is the new Monster class:
```csharp
    public class TrickyMonster : MonoBehaviour
    {
        [TweakDeviate(5)] private int health = 100;
        [TweakDeviate(30f, 5f)] private float speed = 100;

        public void CleanUp()
        {
            health = 100;
            speed = 100;
        }

        public void Awake()
        {
            TweakInjector.Inject(this, CleanUp);
        }
    }
```
###TweakDeviate
TweakDeviate attribute allows you to get the initial value defined for the value and update it by a certain percent.
If only one value is specidied for the attribute, the new value will be:
*old value - (old value • percent) ≤ old value ≤ old value + (old value • percent)*

In our example, the injected value for the health will be between 95 and 105.

By specifying <b>2 parameters</b> for the attribute, you set up the Up Percent and the Down Percent.

In our example, the injected value for the speed will be between 70 and 105.

In Unity, the TweakDeviate attribute can be used in conjunction with another reflection-based tools such as [Zenject](https://github.com/modesttree/Zenject). Since Zenject code runs prior any other code in the scene, you can Inject the default values using Zenject and then randomize it with RTweak.
###TweakInjector.Inject(object, Action) overload
If you use TweakDeviate several times for the same object, the initial value will be different on each use. This might be a problem, since the the value can become too big or too small for a certain type.
To handle that, you can pass the method that returns the object to the initial state to the Inject method. The method will be invoked before the actual inject.
This overload is especially useful if you use the Object Pool pattern.

In our example, we pass the *CleanUp* method as a parameter, and it will return the health and speed values to the initial ones.