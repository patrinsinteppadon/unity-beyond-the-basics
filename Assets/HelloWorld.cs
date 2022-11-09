using System.Linq;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public int maxRandom;

    private void Start()
    {
        // SayHelloWorld();
        AnonymousTypeExample();
    }

    private void SayHelloWorld()
    {
        var randomNumber = UnityEngine.Random.Range(0, maxRandom);
        var displayText = "Hello World!";

        for (int i = 0; i < randomNumber; i++)
        {
            Debug.Log(displayText);
        }

    }

    private void AnonymousTypeExample()
    {
        var enemies = new[] {
            new { name = "Goomba", hitPoints = 100 },
            new { name = "Alligator", hitPoints = 200 }
        };

        // this is a LINQ query
        // iterates through 'enemies' and returns the collection
        // ordered by enemyname
        var enemyQuery = from enemy in enemies
                         orderby enemy.name
                         select enemy;

        foreach (var enemy in enemyQuery)
        {
            Debug.Log(enemy.name);
        }
    }
}
