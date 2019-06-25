using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunYoneticisiKod : MonoBehaviour {

    GameObject donenCember;
    GameObject anaCember;
    public Animator animator;
    public Text DonenCemberLevel;
    public Text bir;
    public Text iki;
    public Text uc;
    public int kacTaneKucukCemberOlsun;
    bool kontrol = true;
    void Start () {
        PlayerPrefs.SetInt("kayit",int.Parse(SceneManager.GetActiveScene().name));
        
        donenCember = GameObject.FindGameObjectWithTag("donencembertag");
        anaCember = GameObject.FindGameObjectWithTag("anacembertag");
        DonenCemberLevel.text = SceneManager.GetActiveScene().name;

        if(kacTaneKucukCemberOlsun < 2)
        {
            bir.text = kacTaneKucukCemberOlsun+"";
        }
        else if (kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun-1) + "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun-1) + "";
            uc.text = (kacTaneKucukCemberOlsun-2) + "";
        }


	}
    public void KucukCemberlerdeTextGosterme()
    {
        kacTaneKucukCemberOlsun--;
        if (kacTaneKucukCemberOlsun < 2)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = "";
            uc.text = "";
        }
        else if (kacTaneKucukCemberOlsun < 3)
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }
        if(kacTaneKucukCemberOlsun == 0)
        {
            StartCoroutine(yenilevel());
        }
    }
	IEnumerator yenilevel()
    {
        donenCember.GetComponent<Dondurme>().enabled = false;
        anaCember.GetComponent<AnaCemberKod>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (kontrol)
        {
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(1.4f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
           
        }
        
    }
    public void OyunBitti()
    {
        StartCoroutine(CagrilanMetot());
    }
     
    IEnumerator CagrilanMetot()
    {
        donenCember.GetComponent<Dondurme>().enabled = false;
        anaCember.GetComponent<AnaCemberKod>().enabled = false;
        animator.SetTrigger("oyunbitti");
        kontrol = false;
        yield return new WaitForSeconds(1);
        

        SceneManager.LoadScene("AnaMenu");

    }
}
