using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitEntry : MonoBehaviour
{

    public InputField entry;
    public Text page;
    public InputField title;
    public Dropdown entries;
    List<Dropdown.OptionData> header=new List<Dropdown.OptionData>();
    Journal test = new Journal("a", "b");
    List<Journal> diary=new List<Journal>();
   
    // Start is called before the first frame update
    public void MyDemoButton()
    {
        if (title.text != "")
        {
            page.text = entry.text;
            // entry.text = "";
            Journal journal = new Journal(title.text, entry.text);
            if (!hasEntry(journal))
            {
                diary.Add(journal);
                addToEntries(diary);
            }
            else if (journal.getTitle() != "View Previous Entries")
            {
                diary.RemoveAt(findEntry(journal));
                diary.Add(journal);

            }
        }
    }
    public void showEntry()
    {
        string t = entries.options[entries.value].text;
        for (int i = 0; i < diary.Count; i++)
        {
            if (diary[i].getTitle() == t)
            {
                page.text = diary[i].getPage();
                title.text = diary[i].getTitle();
                entry.text = page.text;
                i = diary.Count;
            }
        }
        if(t.Equals("View Previous Entries"))
        {
            page.text = "";
            title.text = "";
            entry.text = "";
        }
    }

    public void addToEntries(List<Journal> journals)
    {
        List<string>entries2=new List<string>();
        entries2.Add("View Previous Entries");
        foreach(Journal journal in journals)
        {
            entries2.Add(journal.getTitle());
        }
        entries.ClearOptions();
        entries.AddOptions(entries2);
        entries.RefreshShownValue();
    }

    public bool hasEntry(Journal journal)
    {
        foreach(Journal have in diary)
        {
            if(have.getTitle().Equals(journal.getTitle()))
            {
                return true;
            }
        }
        return false;
    }
    public int findEntry(Journal journal)
    {
        for (int i = 0;i < diary.Count;i++)
        {
            if ((diary[i].getTitle().Equals(journal.getTitle())))
            {
                return i;
            }
        }
        return 0;
    }
    public void updated()
    {
        page.text = entry.text;
    }

  /*  public void chooseEntry()
    {
        string selected = entries.options[]
    }
  */
    // Update is called once per frame
  
}
public class Journal
{
    public string title;
    public string page;

    public Journal(string t, string p) { 
        title = t;
        page = p;
    }
    public string getPage() { return page; }

    public string getTitle() { return title; }
}
