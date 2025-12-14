using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fimfase : MonoBehaviour
{
public float fadeDuration = 1f;
public float displayImageDuration = 1f;
public GameObject player;

bool m_IsPlayerAtExit;
bool m_IsPlayerCaught;
float m_Timer;

public static Fimfase instance;

[SerializeField]
public Image m_EndScreen,m_CaughtScreen;

void Start()
{
instance = this;
}

void OnTriggerEnter (Collider other)
{
if (other.gameObject == player)
{
m_IsPlayerAtExit = true;
}
}

public void CaughtPlayer ()
{
m_IsPlayerCaught = true;
}

void Update ()
{
if (m_IsPlayerAtExit)
{
EndLevel (m_EndScreen, false);
}
else if (m_IsPlayerCaught)
{
EndLevel (m_CaughtScreen, true);
}
}

void EndLevel (Image element, bool doRestart)
{
//aumenta a opacidade da imagem a deixando visivel
m_Timer += Time.deltaTime;

element.gameObject.SetActive(true);

if (m_Timer > displayImageDuration)
{
if (doRestart)
{
SceneManager.LoadScene ("Main");
}
else
{
Application.Quit ();
Time.timeScale = 0;
}
}
}
}
