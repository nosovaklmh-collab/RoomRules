using UnityEngine;
using UnityEditor;

public class Level2Builder : EditorWindow
{
    [MenuItem("Tools/Build Level2 Puzzle")]
    static void BuildLevel()
    {
        CreateColoredSquare("Box", new Vector3(0, -1.5f, 0), new Vector3(1, 1, 1), new Color(0.6f, 0.4f, 0.2f), true);
        CreateColoredSquare("Platform_Door", new Vector3(6, 1, 0), new Vector3(3, 0.5f, 1), Color.gray, false);

        GameObject door = GameObject.Find("Door");
        if (door != null)
            door.transform.position = new Vector3(6, 2.2f, 0);
        else
            Debug.LogWarning("Door не найден в сцене Ч передвиньте вручную.");

        GameObject button = GameObject.Find("GravityButton");
        if (button != null)
            button.transform.position = new Vector3(-3, -2.5f, 0);
        else
            Debug.LogWarning("GravityButton не найден в сцене Ч передвиньте вручную.");

        GameObject player = GameObject.Find("Player");
        if (player != null)
            player.transform.position = new Vector3(-6, -2, 0);

        Debug.Log("Level2 собран!");
    }

    static void CreateColoredSquare(string name, Vector3 position, Vector3 scale, Color color, bool isPhysical)
    {
        GameObject obj = new GameObject(name);
        obj.transform.position = position;
        obj.transform.localScale = scale;

        Texture2D tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.white);
        tex.Apply();
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1);

        SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        sr.color = color;

        obj.AddComponent<BoxCollider2D>();

        if (isPhysical)
        {
            obj.AddComponent<Rigidbody2D>();
            obj.tag = "Physical";
        }
    }
}