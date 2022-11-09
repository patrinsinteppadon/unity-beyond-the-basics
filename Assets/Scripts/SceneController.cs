using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public string[] names = { "circle", "square", "triangle", "octagon" };
    public List<string> moreShapes;
    public List<Shape> gameShapes;
    public Dictionary<string, Shape> shapeDictionary;
    public Queue<Shape> shapeQueue;

    void Start()
    {
        shapeQueue = new Queue<Shape>();
        shapeDictionary = new Dictionary<string, Shape>();
        foreach (Shape shape in gameShapes)
        {
            shapeDictionary[shape.name] = shape;
            //shapeDictionary.Add(shape.Name, shape);
        }

        shapeQueue.Enqueue(shapeDictionary["Triangle"]);
        shapeQueue.Enqueue(shapeDictionary["Square"]);
        shapeQueue.Enqueue(shapeDictionary["Octagon"]);
        shapeQueue.Enqueue(shapeDictionary["Circle"]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shapeQueue.Count > 0)
        {
            Shape shape = shapeQueue.Dequeue();
            shape.SetColor(Color.cyan);
        }
    }

    private void SetRedByName(string shapeName)
    {
        shapeDictionary[shapeName].SetColor(Color.red);
    }

    private void ListExample()
    {
        moreShapes = new List<string> { "circle", "square", "triangle", "octagon" };
        moreShapes.Add("rectangle");
        moreShapes.Insert(2, "diamond");
        moreShapes.Sort();

        foreach (string name in moreShapes)
        {
            Debug.Log(name.ToUpper());
        }
    }

    private void FindExample()
    {
        shapeDictionary = new Dictionary<string, Shape>();
        Shape octagon = gameShapes.Find(s => s.Name == "Octagon");
        shapeDictionary.Add("Octagon", octagon);
        octagon.SetColor(Color.red);
    }
    private void DictionaryExample()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetRedByName("Square");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SetRedByName("Circle");
        }
    }
}
