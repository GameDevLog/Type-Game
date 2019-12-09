using UnityEngine;

public class WordController : MonoBehaviour
{
    public float mytimer = 1f;
    public float gravity = -10f;
    public GUISkin skin;

    private int position; 
    private string showString;
    private string word; // "Hello"
    private string preWord; // match pre "He"
    private string postWord; // match post "llo"
    private string hitColor = "#00ff00";
    private string hitChar;
    private string defaultColor = "#ffffff";
    private Vector3 transformPos3D;
    private Vector2 transformPos2D;
    private Transform myTransform;
    private Camera mainCamera;
    private bool isBlow;
    private string explain;
    private int lengthChange;
    private bool oncecal;

    void Start()
    {
        oncecal = false;
        word = WordSwapner.instance.word;
        explain = WordSwapner.instance.explain;
        position = -1;
        mainCamera = Camera.main;
        myTransform = this.transform;
        isBlow = false;
        lengthChange = word.Length * 10;
    }

    void Update()
    {
        Physics.gravity = new Vector3(0, gravity, 0);

        if (!isBlow)
        {
            if (position == -1)
            {
                showString = word;
            }
            if (Input.anyKeyDown)
            {
                position++;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                hitChar = "a";
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                hitChar = "b";
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                hitChar = "c";
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                hitChar = "d";
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                hitChar = "e";
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                hitChar = "f";
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                hitChar = "g";
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                hitChar = "h";
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                hitChar = "i";
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                hitChar = "j";
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                hitChar = "k";
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                hitChar = "l";
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                hitChar = "m";
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                hitChar = "n";
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                hitChar = "o";
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                hitChar = "p";
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hitChar = "q";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                hitChar = "r";
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                hitChar = "s";
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                hitChar = "t";
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                hitChar = "u";
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                hitChar = "v";
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                hitChar = "w";
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                hitChar = "x";
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                hitChar = "y";
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                hitChar = "z";
            }
            if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
            {
                hitChar = "0";
            }
            if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            {
                hitChar = "1";
            }
            if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                hitChar = "2";
            }
            if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            {
                hitChar = "3";
            }
            if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
            {
                hitChar = "4";
            }
            if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
            {
                hitChar = "5";
            }
            if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
            {
                hitChar = "6";
            }
            if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
            {
                hitChar = "7";
            }
            if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
            {
                hitChar = "8";
            }
            if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
            {
                hitChar = "9";
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hitChar = " ";
            }
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                hitChar = "-";
            }
            if (Input.GetKeyDown(KeyCode.Period))
            {
                hitChar = ".";
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                hitChar = "Return";
            }

            if (position < WordSwapner.instance.midBreak)
            {    
                position = -1;
                return;
            }

            if ((position >= 0) && (position < word.Length))
            {
                preWord = word.Substring(0, position + 1);
                postWord = word.Substring(position + 1);

                if (!word.Substring(position, 1).ToLower().Equals(hitChar))
                {
                    position = -1;
                    WordSwapner.instance.midBreak = -1;
                }
                else
                {
                    WordSwapner.instance.midBreak = position;

                    showString = "<color=" + hitColor + ">" + preWord + "</color><color=" + defaultColor + ">" + postWord + "</color>";
                }
                return;
            }
        }

        if (position >= word.Length - 1)
        {
            if (hitChar.Equals("Return"))
            {
                WordSwapner.instance.midBreak = -1;

                if (!oncecal)
                {
                    lengthChange = explain.Length * 15;
                    oncecal = true;
                }
                showString = "<color=white>" + explain + "</color>";

                mytimer -= Time.deltaTime * 2;

                if (mytimer <= 0 && !isBlow)
                {
                    isBlow = true;
                    TypeGUI.instance.score += 1;

                    if (TypeGUI.instance.score > TypeGUI.instance.highScore)
                    {
                        TypeGUI.instance.highScore = TypeGUI.instance.score;
                    }
                }
                else
                {
                    print("Press 'Enter' to end!");
                }
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;
        transformPos3D = transform.position;
        transformPos2D = mainCamera.WorldToScreenPoint(transformPos3D);
        transformPos2D = new Vector2(transformPos2D.x, Screen.height - transformPos2D.y);

        if (!isBlow)
        {
            GUI.Box(new Rect(transformPos2D.x, transformPos2D.y, lengthChange*3, 64), showString);   
        }
        else
        {
            Destroy(this.gameObject, 1);
        }
    }
}
