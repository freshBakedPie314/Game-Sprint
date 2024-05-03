using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Door door;
    public PlayerStats data;

    public List<GameObject> upgrades;
    public List<Upgrade> upgradesSO;
    // Start is called before the first frame update
    public GameObject buttonParent;
    public GameObject choicePanel;
    private void Awake()
    {
        Door.isOpened += displayUpgrades;
        Upgrade.upgradeSelected += DisablePanel;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enimies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enimies.Length <= 0) door.isClosed = false;
    }
    GameObject button1, button2, button3;
    public void displayUpgrades()
    {
        if(!choicePanel.activeSelf)
        {
            List<GameObject> upgradeCopy = new List<GameObject>(upgrades);
            List<Upgrade> upgradeSOCopy = new List<Upgrade>(upgradesSO);

            int ind1 = Random.Range(0, upgradeCopy.Count);
            button1 = Instantiate(upgradeCopy[ind1], buttonParent.transform);
            button1.GetComponentInChildren<Text>().text = upgradeSOCopy[ind1].text;
            upgradeCopy.Remove(upgradeCopy[ind1]);
            upgradeSOCopy.Remove(upgradeSOCopy[ind1]);

            int ind2 = Random.Range(0, upgradeCopy.Count);
            button2 = Instantiate(upgradeCopy[ind2], buttonParent.transform);
            button2.GetComponentInChildren<Text>().text = upgradeSOCopy[ind2].text;
            upgradeCopy.Remove(upgradeCopy[ind2]);
            upgradeSOCopy.Remove(upgradeSOCopy[ind2]);

            int ind3 = Random.Range(0, upgradeCopy.Count);
            button3 = Instantiate(upgradeCopy[ind3], buttonParent.transform);
            button3.GetComponentInChildren<Text>().text = upgradeSOCopy[ind3].text;

            choicePanel.SetActive(true);
        }
    }

    private void DisablePanel()
    {
        choicePanel.SetActive(false);
        Destroy(button1);
        Destroy(button2);
        Destroy(button3);
    }
}
