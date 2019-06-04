using System;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
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
                    List<RouteEntity> routeList = new List<RouteEntity>();
                    while (reader.Read())
                    {
                        RouteEntity entity = new RouteEntity(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                        Debug.Log("Liste:" + entity._listofwaypoints);
                        routeList.Add(entity);
                        LineOfScrimmageGenerator.isroutegezogen(entity._listofwaypoints);
                    }
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