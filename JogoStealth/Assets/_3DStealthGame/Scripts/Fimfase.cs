using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fimfase : MonoBehaviour
{
public float fadeDuration = 1f;
public float displayImageDuration = 1f;
public GameObject player;

[SerializeField] AudioClip vitoriaClip, pegoClip;

bool m_IsPlayerAtExit;
bool m_IsPlayerCaught;
float m_Timer;

public static Fimfase instance;

[SerializeField]
public Image m_EndScreen,m_CaughtScreen;

private float timer;

void Start()
{
instance = this;
}

void OnTriggerEnter (Collider other)
{
if (other.gameObject == player)
{
m_IsPlayerAtExit = true;
SFXCotroller.instance.TocarSFX(vitoriaClip);
}
}

public void CaughtPlayer()
{
m_IsPlayerCaught = true;
}

void Update ()
{
if (m_IsPlayerAtExit)
{
EndLevel (m_EndScreen, false,vitoriaClip);
}
else if (m_IsPlayerCaught)
{
EndLevel (m_CaughtScreen, true,pegoClip);
}
}

void EndLevel (Image element, bool doRestart,AudioClip clip)
{
//aumenta a opacidade da imagem a deixando visivel
m_Timer += Time.deltaTime/fadeDuration;

element.gameObject.SetActive(true);

SFXCotroller.instance.TocarSFX(clip);

if (m_Timer > displayImageDuration + fadeDuration)
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
