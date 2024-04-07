using System.Collections;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject Angelo;
    public Transform spawnMe;
    public Transform leonardo;
    public GameObject winTheGame;
    private bool keyset;
    private GameObject _angelo;
    [SerializeField] private AudioSource audio;
    [SerializeField] private CatMove catMoveScript;

    private void Start()
    {
        keyset = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !keyset)
        {
            audio.Play();
            StartCoroutine(SpawnAngeloAndFocusCamera());
        }

        //Cheat to kill Angelo
        if (Input.GetKeyDown(KeyCode.K))
        {
            _angelo.GetComponent<EnemyHealth>().botHealth = 0;
        }
    }

    private IEnumerator SpawnAngeloAndFocusCamera()
    {
        // Tworzenie Angelo
        var instanceAngello = Instantiate(Angelo, spawnMe.position, spawnMe.rotation);
        _angelo = instanceAngello;

        // Tymczasowe wyłączenie kontrolera kamery w CatMove
        catMoveScript.enabled = false;

        // Skupienie kamery na Angelo na chwilę
        Camera.main.transform.LookAt(instanceAngello.transform);

        yield return new WaitForSeconds(2f);

        // Przekazanie kodu ruchu do Angelo
        BotMoveLogic botMove = _angelo.AddComponent<BotMoveLogic>();
        botMove.target = leonardo;
        _angelo.GetComponent<AngelloFailTheMission>().winGame = winTheGame;

        // Oczekiwanie przez krótki czas
        yield return new WaitForSeconds(2f);

        // Przywrócenie kontroli kamery do CatMove
        catMoveScript.enabled = true;
    }
}