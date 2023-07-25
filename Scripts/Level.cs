using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Level : MonoBehaviour
{
    [SerializeField]
    private int _levelIndex;
    public int levelCount;
    // [SerializeField]
    // private int _collectedKeys = 0;
    // [SerializeField]
    // private string _levelsPath = "/Assets/Levels/1.txt"; 
    // private char[] _positions = new char[100];

    // When creating a level, always make sure that the bottom right unit is empty.
    // Because that is where the player will spawn.
    // [SerializeField]
    // private int _currentLevel = 0;
    // private float[] _xValues = {7.79f, 7.79f, 7.79f, 7.79f, 7.79f, 7.79f, 7.79f, 7.79f, 7.79f, 7.79f};
    // private float[] _zValues ={6.11f, 4.11f, 2.11f, };
    private float x = 17.3f; // 7.79
    private float z = 62.8f; // 6.11
    // rpviate
    private int _rowCount = 1;
    // Create GameObject vars necessary for instantiation of ALL Objects for new levels
    public GameObject obstaclePrefab;
    public GameObject obstacleContainer;
    private GameObject _obstacleInstantiation;
    public GameObject keyPrefab;
    public GameObject keyContainer;
    private GameObject _keyInstantiation;
    public GameObject spikePrefab;
    public GameObject spikeContainer;
    private GameObject _spikeInstantiation;
    private Vector3 _resetPos = new Vector3(-1f, -8.8f, 44.59f);
    public GameObject beatModal;
    // public GameObject player;
    
    // private GameObject[] _currentKeys = GameObject.FindGameObjectsWithTag("Key");
    // Store the level formats in a 2D Array.
    private string[,] _levels = new string[,] {
        {
            "###^      ",
            "# $       ", 
            "###^      ",
            "          ",
            "      ####",
            "       $ #",
            "      ####",
            "          ",
            "####      ",
            "# $       "
        },

        {
            "##### ^  #",
            "# $ #     ", 
            "#         ",
            "     # # #",
            "     # $ #",
            "     #####",
            "  #^#     ",
            "          ",
            "##$#     ^",
            "##        "
        },

        {
            "#####  $ #",
            "#####    #", 
            "^       ##",
            "#    #####",
            "^      $ #",
            "     #####",
            "  ### ^^^^",
            "$#        ",
            " #        ",
            "          "
        },

        {
            "#^#^#^# $^",
            "######^ ^#", 
            "          ",
            "#    #####",
            "^     $  ^",
            "     ## ##",
            " ^#####^##",
            " # ^      ",
            "        ^ ",
            "$#######  "
        },

        {
            "#$     ^##",
            "# #^## ^ #", 
            "^ ^  ^    ",
            "# #^# #^ #",
            "^$        ",
            "# ###^ ^##",
            "# ####    ",
            "# #^####^ ",
            "^         ",
            "#$##      "
        },

        {
            "    ^^^###",
            "^      #$#", 
            "   ^  ^# #",
            "# $#   ^ ^",
            "#  #   #  ",
            "####   #  ",
            "       #  ",
            "####^  #  ",
            "^ $       ",
            "####   #  "
        },

        {
            "^   ^####^",
            "# #  # $  ", 
            "  ^^^#### ",
            "  ^$^   ^ ",
            "  # #   ^ ",
            "     #### ",
            "  ^       ",
            " #$ #     ",
            " ^########",
            "          "
        },

        {
            "#$#   ####",
            "^     #  #", 
            "#^^^  ^^^#",
            "    ^####^",
            "       $  ",
            "      ###^",
            "#^^^  ^^^#",
            "####^     ",
            "#$        ",
            "####^     "
        },

        {
            "     ###  ",
            "     #$#  ", 
            "    ^  ^  ",
            "      ####",
            "        $ ",
            "^     ^^^^",
            "#   #     ",
            "#   #     ",
            "# $ #     ",
            "#####     "
        },

        {
            "          ",
            "          ",
            "  ##### ^ ", 
            "          ",
            "  ####### ",
            "  #  $  # ",
            "  ####### ",
            "  $     $ ",
            "  ####### ",
            "   $      "
        },

        {
            "^#^$#   # ",
            "#$^    # ^", 
            "# ^   #^  ",
            "     #^^^ ",
            "     $    ",
            "^^^  #^   ",
            "^   #     ",
            "  ^#      ",
            "  #       ",
            " #        "
        },

        {
            "####^    $",
            "   #  ####", 
            "   #  #   ",
            "   #  #^ ^",
            "^     #   ",
            "#$#     ^ ",
            "###   ###^",
            "    ^    $",
            " ^  ######",
            "  ^       "
        },

        {
            "  $^  # ##",
            " ###  ####", 
            "      #   ",
            "   ^#^    ",
            " ^  $  ^  ",
            "   ^#^    ",
            " #    #  #",
            "    ^     ",
            " ##  # ## ",
            " ###$## # "
        },

        {
            "$      ^  ",
            "###### ^  ", 
            "^         ",
            "      ^$^ ",
            "^  #######",
            "          ",
            "$^        ",
            "#####  ^^^",
            "    ^    ^",
            "    ^ #   "
        },

        {
            "^^#   ^  $",
            "$^#      ^", 
            " ^#   ^   ",
            " ^#       ",
            " ^#      ^",
            "     #^   ",
            "^    #^   ",
            "   ^ #^   ",
            "^$   #^   ",
            "#^   #    "
        },

        {
            "$^   ###^#",
            "   ^    ^#", 
            "####### ##",
            "          ",
            "     #^^##",
            "^    # $ ^",
            "       #^ ",
            " ^      # ",
            " ##^ ^### ",
            "$^        "
        },

        {
            "###     ##",
            "^   ^$^  ^", 
            "^    ^   ^",
            "^    ^    ",
            "#### ^ ## ",
            "       ^$ ",
            " # ^# #^##",
            "$ ^       ",
            "   # #    ",
            "   #      "
        },

        {
            "       ###",
            "       #$#", 
            "       ^ ^",
            "## #^ ^   ",
            "#^$#      ",
            "^^        ",
            "   ^ ##^##",
            "     # $ #",
            "     #^ ^#",
            "          "
        },

        {
            " $   ^  ^ ",
            "^ ^  ^ $  ", 
            "       ^  ",
            "     ^   ^",
            "    ^     ",
            "  ^   ^   ",
            "    $     ",
            "####^ ^###",
            "          ",
            "          "
        },

        {
            "  ^^^^^^  ",
            "    $  ^  ",
            "  ^^^^^^  ",
            "  ^  $    ",
            "  ^^^^^^  ",
            "    $     ",
            "  ^^^^^^  ",
            "  ^    ^  ",
            "  ^    ^  ",
            "  ^^^^^^  "
        },

        {
            "   ^$^    ",
            "   # ^    ", 
            "          ",
            "      ### ",
            "#         ",
            "^      ^  ",
            "$##       ",
            "      ^$ ^",
            "^^^^^^^^ ^",
            "          "
        },

        {
            "  ^     ^ ",
            "  ^ # $  ^",
            "    ##^  ^",
            "#^ ^#    ^",
            " ^$ #    ^",
            "##^##^##  ",
            "$  # ^   ^",
            "  ^    ^  ",
            "    #     ",
            "   ^^^^   "
        },


        {
            "  $  ^^^  ",
            "  $  ^$   ",
            "  $  ^^  ^",
            "  $  ^  ^ ",
            "  $  ^ ^  ",
            "  $  ^ ^  ",
            "  $  ^    ",
            "  $  ^$^^ ",
            "^^^^^^^^^$",
            "          "
        }

    };

    // Start is called before the first frame update
    void Start()
    {

        // Set up the level based on the level file
        // This will only run once, and it will be to generate the first level
        // Debug.Log("Start");
        // Get specific currently existing objects in game
        _levelIndex = PlayerPrefs.GetInt("Level");
        renderLevel();
        
    }

    // Update is called once per frame
    void Update()
    {

        /*if (_collectedKeys == 3)
        {
            _collectedKeys = 0;
            _level++;
            nextLevel();
        }*/
        
    }
    public void restartGame() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = _resetPos;
        _levelIndex = 0;
        levelCount = _levelIndex + 1;
        PlayerPrefs.SetInt("Level", 0);
        GameObject[] _currentSpikes = GameObject.FindGameObjectsWithTag("Spikes");
        GameObject[] _currentObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] _currentKeys = GameObject.FindGameObjectsWithTag("Key");
        // Reusing i by creating it from scrath
        for (int i = 0; i < _currentSpikes.Length; i++)
        {
            Debug.Log("Destroying SPIKE");
            Destroy(_currentSpikes[i].gameObject);
        }
        for (int i = 0; i < _currentObstacles.Length; i++)
        {
            Debug.Log("Destroying Obstacle");
            Destroy(_currentObstacles[i].gameObject);
        }
        for (int i = 0; i < _currentKeys.Length; i++)
        {
            Debug.Log("Destroying Key");
            Destroy(_currentKeys[i].gameObject);
        }
        renderLevel();
    }

    public void restartLevel() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = _resetPos;
        GameObject[] _currentSpikes = GameObject.FindGameObjectsWithTag("Spikes");
        GameObject[] _currentObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] _currentKeys = GameObject.FindGameObjectsWithTag("Key");
        for (int i = 0; i < _currentSpikes.Length; i++)     
        {
            Debug.Log("Destroying SPIKE");
            Destroy(_currentSpikes[i].gameObject);
        }
        for (int i = 0; i < _currentObstacles.Length; i++)
        {
            Debug.Log("Destroying Obstacle");
            Destroy(_currentObstacles[i].gameObject);
        }
        for (int i = 0; i < _currentKeys.Length; i++)
        {
            Debug.Log("Destroying Key");
            Destroy(_currentKeys[i].gameObject);
        }
        renderLevel();
    }

    public void nextLevel() 
    {
        _levelIndex++;
        levelCount = _levelIndex + 1;
        PlayerPrefs.SetInt("Level", _levelIndex);
        // Debug.Log($"Completed level {_level-1}, and moving on to {_level}");
        // I'm so confused right now
        Debug.Log("YOU WON!!! Rendering next level...");
        // _currentLevel++;
        // Destroy current
        GameObject[] _currentSpikes = GameObject.FindGameObjectsWithTag("Spikes");
        GameObject[] _currentObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] _currentKeys = GameObject.FindGameObjectsWithTag("Key");
        // Reusing i by creating it from scrath
        for (int i = 0; i < _currentSpikes.Length; i++)
        {
            Destroy(_currentSpikes[i].gameObject);
        }
        for (int i = 0; i < _currentObstacles.Length; i++)
        {
            Destroy(_currentObstacles[i].gameObject);
        }
        for (int i = 0; i < _currentKeys.Length; i++)
        {
            Debug.Log("Destroying Key");
            Destroy(_currentKeys[i].gameObject);
        }
        // Debug.Log(_levels.Length);
        /*if (_levelIndex+1 == _levels.Length)
        {
            Debug.Log("Level index equal level length - 1. Reached final level");
            _levelIndex = 0;
            Instantiate(beatModal);
            GameObject victoryModal = GameObject.FindGameObjectWithTag("Victory");
            Destroy(victoryModal.gameObject);
             for (int i = 0; i < victoryModal.Length; i++)
            {
                Destroy(victoryModal[i].gameObject);
            } 
        }*/
        renderLevel();
        
    }

    void renderLevel() {
        // Debug.Log("Called AGain");
        // // Dictionary<int, float> position = new Dictionary<int, float>();
        // foreach (string line in File.ReadLines(_levelsPath))
        // {
        //     Debug.Log(line);
        // }
        levelCount = _levelIndex + 1;
        PlayerPrefs.SetInt("Level", _levelIndex);
        Debug.Log(_levelIndex);
        Debug.Log(_levels.GetLength(0));
        if (_levelIndex == _levels.GetLength(0))
        {
            Debug.Log("You've reached the end.");
            Instantiate(beatModal);
            GameObject victoryModal = GameObject.FindGameObjectWithTag("Victory");
            Destroy(victoryModal.gameObject);
            restartGame();
            return;
        }

        for (int i = 0; i < 10; i++) // GetLength(num) gets the length of the nested array.
        {
            Debug.Log($"Logging rendering list for level {_levelIndex+1}");
            string row = _levels[_levelIndex,i];
            // Debug.Log(row);

            for (int j = 0; j < 10; j++)
            {
                //1.31f
                if (row[j].ToString() == "#")
                {
                    Debug.Log($"Creating Obstacle @ position ({z}, {x})");
                    // Debug.Log("Creating obstacle");
                    _obstacleInstantiation = Instantiate(obstaclePrefab, new Vector3(x, -9.5f, z), Quaternion.identity); // y was 11.4f
                    _obstacleInstantiation.transform.SetParent(obstacleContainer.transform);
                }
                else if (row[j].ToString() == "$") {
                    Debug.Log($"Creating Key @ position ({z}, {x})");
                    // Debug.Log("Creating key");
                    _keyInstantiation = Instantiate(keyPrefab, new Vector3(x, -9f, z), Quaternion.identity);
                    _keyInstantiation.transform.SetParent(keyContainer.transform);
                }
                else if (row[j].ToString() == "^") {
                    Debug.Log($"Creating Spike @ position ({z}, {x})");
                    _spikeInstantiation = Instantiate(spikePrefab, new Vector3(x, -9.5f, z), Quaternion.identity);
                    _spikeInstantiation.transform.SetParent(spikeContainer.transform);
                } 
                if (_rowCount == 10) 
                {
                    _rowCount = 1;
                    x -= 2f;
                    // -
                    z = 62.8f; // was 6.11f

                } else {
                    _rowCount++;
                    z -= 2f;
                    // +
                }
            } 
        }
        // _currentLevel++;
        // _levelIndex++; // _currentLevel variable is now unused. Use the _levelIndex for array values.
        // Reset the position values after rendering level to prepare for next level advancement
        x = 17.3f;
        z = 62.8f;
    }
}
