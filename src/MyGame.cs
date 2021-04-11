using System;
using CatRPG;

public class MyGame {
    public static void Main (string[] args) {
        CatGame game = new CatGame (1080, 720, "CatRPG Engine");

        game.SetUpdateFrameFrequency (60.0f);

        Scene scene = new Scene ();
        GameObject go = new GameObject ("Test GameObject");
        TestScript script = new TestScript ();

        AudioClip clip = ResourceLoader.LoadAudioClip("test.ogg");
        AudioSource source = new AudioSource();
        source.SetClip(clip);
        
        go.AddComponent(source);
        go.AddComponent(script);
        scene.AddGameObject(go);

        game.GetSceneManager().AddScene ("Test Scene", scene);
        game.GetSceneManager().SetScene ("Test Scene");

        source.Play();

        game.InitAndLockThread();
    }
}

public class TestScript : Behaviour {

    private Texture2D texture;

    public override void Start () {
        this.texture = ResourceLoader.LoadTexture ("test.png");
    }

    public override void Update () {

        Drawer.DrawTexture (this.texture);

        if (Input.IsKeyDown (KeyCode.A)) {
            Console.WriteLine ("Mover Izquierda");
        }

        if (Input.IsKeyDown (KeyCode.S)) {
            Console.WriteLine ("Mover Abajo");
        }

        if (Input.IsKeyDown (KeyCode.D)) {
            Console.WriteLine ("Mover Derecha");
        }

        if (Input.IsKeyDown (KeyCode.W)) {
            Console.WriteLine ("Mover Arriba");
        }
    }
}