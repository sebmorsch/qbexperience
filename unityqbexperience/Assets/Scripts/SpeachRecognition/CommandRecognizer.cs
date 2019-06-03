using System;
using UnityEngine;
using UnityEngine.Windows.Speech;
//own import
using DataBank;

public class CommandRecognizer
{
    private string[] command;
    Boolean commandhere; 

    private KeywordRecognizer commandRecognizer;

    public void startCommandRecognition()
    {
        commandhere = false;
        command = new string[3];
        command[0] = Commandstrings.COMMANDWURFTRAINING;
        command[1] = Commandstrings.COMMANDFLY;
        command[2] = Commandstrings.COMMANDPOST;
        commandRecognizer = new KeywordRecognizer(command);
        commandRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        commandRecognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        setCommandHere(true);
        switch (args.text)
        {
            case Commandstrings.COMMANDROUTETRAINING:
                Debug.Log(args.text);
                break;
            case Commandstrings.COMMANDWURFTRAINING:
                Debug.Log(args.text);
                break;
            default:
                Debug.Log(args.text);
                QBExperienceDb qbdb = new QBExperienceDb();
                try
                {
                    System.Data.IDataReader reader = qbdb.getDataByString(args.text);
                    RouteEntity entity = new RouteEntity(reader[0].ToString(),reader[1].ToString(),reader[2].ToString());
                }
                catch(Exception e)
                {
                    Debug.Log("FEHLER");
                }

                //Mit Wert in Datenbank suchen

                break;
        }  
    }

    public void stopCommandRecognizer()
    {
        commandRecognizer.Stop();
        commandRecognizer.Dispose();
    }

    public Boolean getCommandHere()
    {
        return commandhere;
    }

    private void setCommandHere(Boolean commandhere)
    {
        this.commandhere = commandhere;
    }
}