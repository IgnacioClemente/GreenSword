using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JsonManager : MonoBehaviour
{
    CharacterBase[] players;
    Items[] items;
    Quest[] quest;

    private void Awake()
    {
        string jsonPlayers = LoadText("Player.txt");
        players = LoadJsonPersonaje(jsonPlayers);
        string jsonItems = LoadText("Items.txt");
        items = LoadJsonItems(jsonItems);
        string jsonQuest = LoadText("Quest.txt");
        quest = LoadJsonQuest(jsonQuest);
    }

    public CharacterBase[] GetPlayers()
    {
        return players;
    }
    public Items [] GetItems()
    {
        return items;
    }
    public Items GetItem(string _name)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i]._name == _name)
            {
                return items[i];
            }
        }
        return null;
    }
    public Quest Getquest(string _name)
    {
        for (int i = 0; i < quest.Length; i++)
        {
            if (quest[i]._name == _name)
            {
                return quest[i];
            }
        }
        return null;
    }

    private Items[] LoadJsonItems(string json1)
    {
        JSONObject jsonObj = new JSONObject(json1);
        JSONObject jsonObjaux = jsonObj;

        Items[] itemsArray;
        EquipItems[] equipArray;
        Pasive[] pasivoArray;
        ConstantesItems[] constanteArray;
        ConsumiblesItems[] consumibleArray;

        int equipablesCount = 0;
        int pasivosCount = 0;
        int consumiblesCount = 0;
        int constantesCount = 0;

        if (jsonObjaux.HasField("Equipables"))
            equipablesCount = jsonObjaux.GetField("Equipables").Count;

        if (jsonObjaux.HasField("Pasivos"))
            pasivosCount = jsonObjaux.GetField("Pasivos").Count;

        if (jsonObjaux.HasField("Consumibles"))
            consumiblesCount = jsonObjaux.GetField("Consumibles").Count;

        if (jsonObjaux.HasField("Constantes"))
            constantesCount = jsonObjaux.GetField("Constantes").Count;

        itemsArray = new Items[equipablesCount + pasivosCount + constantesCount + consumiblesCount];
        equipArray = new EquipItems[equipablesCount];
        pasivoArray = new Pasive[pasivosCount];
        constanteArray = new ConstantesItems[constantesCount];
        consumibleArray = new ConsumiblesItems[consumiblesCount];

        for (int h = 0; h < equipablesCount; h++)
        {
            jsonObjaux = jsonObj.GetField("Equipables");
            equipArray[h] = new EquipItems();
            equipArray[h]._name = (jsonObjaux[h].HasField("name")) ? jsonObjaux[h].GetField("name").str : string.Empty;
            equipArray[h].desc = (jsonObjaux[h].HasField("descripcion")) ? jsonObjaux[h].GetField("descripcion").str : string.Empty;

            if (jsonObjaux[h].HasField("Stats"))
            {
                jsonObjaux = jsonObjaux[h].GetField("Stats");
                equipArray[h].itemStats.ataque = (jsonObjaux.HasField("Ataque")) ? jsonObjaux.GetField("Ataque").n : 0;
                equipArray[h].itemStats.defensa = (jsonObjaux.HasField("Defensa")) ? jsonObjaux.GetField("Defensa").n : 0;
            }
        }

        jsonObjaux = jsonObj;
        for (int j = 0; j < pasivosCount; j++)
        {
            jsonObjaux = jsonObj.GetField("Pasivos");
            pasivoArray[j] = new Pasive();
            pasivoArray[j]._name = (jsonObjaux[j].HasField("name")) ? jsonObjaux[j].GetField("name").str : string.Empty;
            pasivoArray[j].desc = (jsonObjaux[j].HasField("descripcion")) ? jsonObjaux[j].GetField("descripcion").str : string.Empty;

            if (jsonObjaux[j].HasField("Stats"))
            {
                jsonObjaux = jsonObjaux[j].GetField("Stats");
                pasivoArray[j].itemStats.ataque = (jsonObjaux.HasField("Ataque")) ? jsonObjaux.GetField("Ataque").n : 0;
                pasivoArray[j].itemStats.defensa = (jsonObjaux.HasField("Defensa")) ? jsonObjaux.GetField("Defensa").n : 0;
                pasivoArray[j].itemStats.altura = (jsonObjaux.HasField("Altura")) ? jsonObjaux.GetField("Altura").n : 0;
            }
        }

        jsonObjaux = jsonObj;
        for (int k = 0; k < consumiblesCount; k++)
        {
            jsonObjaux = jsonObj.GetField("Consumibles");
            consumibleArray[k] = new ConsumiblesItems();
            consumibleArray[k]._name = (jsonObjaux[k].HasField("name")) ? jsonObjaux[k].GetField("name").str : string.Empty;
            consumibleArray[k].desc = (jsonObjaux[k].HasField("descripcion")) ? jsonObjaux[k].GetField("descripcion").str : string.Empty;

            if (jsonObjaux[k].HasField("Stats"))
            {
                jsonObjaux = jsonObjaux[k].GetField("Stats");
                consumibleArray[k].itemStats.ataque = (jsonObjaux.HasField("Ataque")) ? jsonObjaux.GetField("Ataque").n : 0;
                consumibleArray[k].itemStats.defensa = (jsonObjaux.HasField("Defensa")) ? jsonObjaux.GetField("Defensa").n : 0;
                consumibleArray[k].itemStats.vidaCap = (jsonObjaux.HasField("VidaCap")) ? jsonObjaux.GetField("VidaCap").n : 0;
            }
        }

        jsonObjaux = jsonObj;
        for (int l = 0; l < constantesCount; l++)
        {
            jsonObjaux = jsonObj.GetField("Constantes");
            constanteArray[l] = new ConstantesItems();
            constanteArray[l]._name = (jsonObjaux[l].HasField("name")) ? jsonObjaux[l].GetField("name").str : string.Empty;
            constanteArray[l].desc = (jsonObjaux[l].HasField("descripcion")) ? jsonObjaux[l].GetField("descripcion").str : string.Empty;

            if (jsonObjaux[l].HasField("Stats"))
            {
                jsonObjaux = jsonObjaux[l].GetField("Stats");
                constanteArray[l].itemStats.ataque = (jsonObjaux.HasField("Ataque")) ? jsonObjaux.GetField("Ataque").n : 0;
                constanteArray[l].itemStats.defensa = (jsonObjaux.HasField("Defensa")) ? jsonObjaux.GetField("Defensa").n : 0;
                constanteArray[l].itemStats.vidaCap = (jsonObjaux.HasField("VidaCap")) ? jsonObjaux.GetField("VidaCap").n : 0;
                constanteArray[l].itemStats.armadura = (jsonObjaux.HasField("Armadura")) ? jsonObjaux.GetField("Armadura").n : 0;
            }
        }

        int i = 0;
        for (int j = 0; j < equipArray.Length; j++)
        {
            itemsArray[i] = equipArray[j];
            i++;
        }

        for (int j = 0; j < pasivoArray.Length; j++)
        {
            itemsArray[i] = pasivoArray[j];
            i++;
        }

        for (int j = 0; j < consumibleArray.Length; j++)
        {
            itemsArray[i] = consumibleArray[j];
            i++;
        }

        for (int j = 0; j < constanteArray.Length; j++)
        {
            itemsArray[i] = constanteArray[j];
            i++;
        }

        return itemsArray;
    }
    private Quest[] LoadJsonQuest(string json2)
    {
        JSONObject jsonObj = new JSONObject(json2);
        JSONObject jsonObjaux = jsonObj;
        Quest[] questArray;
        int questCount = jsonObj.Count;
        questArray = new Quest[questCount];
        for (int i = 0; i < questCount; i++)
        {
            questArray[i] = new Quest();
            if (jsonObj[i].HasField("Objetivo"))
            {
                jsonObjaux = jsonObj[i].GetField("Objetivo");
                questArray[i].obj = new Objetivo();
                questArray[i].obj.type = (jsonObjaux.HasField("type")) ? (Objetivo.QuestType)(System.Enum.Parse(typeof(Objetivo.QuestType), (jsonObjaux.GetField("type").str))) : Objetivo.QuestType.ERROR;
                questArray[i].obj.cuantitive = (jsonObjaux.HasField("cuantitive")) ? jsonObjaux.GetField("cuantitive").n : 0;
                questArray[i].obj._class = (jsonObjaux.HasField("class")) ? jsonObjaux.GetField("class").n : 0;
            }
            if (jsonObj[i].HasField("Reward"))
            {
                jsonObjaux = jsonObj[i].GetField("Reward");
                questArray[i].reward = new Reward();
                questArray[i].reward.xp = (jsonObjaux.HasField("Xp")) ? (int)jsonObjaux.GetField("Xp").n : 0;
            }
            jsonObjaux = jsonObj[i];
            if (jsonObj[i].HasField("SideQuest"))
            {
                questArray[i].Queststats.sidequest = (jsonObjaux.HasField("SideQuest")) ? jsonObjaux.GetField("SideQuest").n : 0;
            }
            if (jsonObj[i].HasField("Descripcion"))
            {
                questArray[i].desc = (jsonObjaux.HasField("Descripcion")) ? jsonObjaux.GetField("Descripcion").str : string.Empty;
            }
            if (jsonObj[i].HasField("name"))
            {
                questArray[i]._name = (jsonObjaux.HasField("name")) ? jsonObjaux.GetField("name").str : string.Empty;
            }
            if (jsonObj[i].HasField("NextQuest"))
            {
                questArray[i].Queststats.nextquest = (jsonObjaux.HasField("NextQuest")) ? jsonObjaux.GetField("NextQuest").n : 0;
            }

            jsonObjaux = jsonObj;
        }
            return questArray;
    }

    private string LoadText(string path)
    {
        //abrir enlace de texto para lectura
        string text = string.Empty;
        text = File.ReadAllText(path);
        return text;
    }

    private CharacterBase[] LoadJsonPersonaje(string json)
    {
        JSONObject jsonObj = new JSONObject(json);
        JSONObject jsonObjaux = jsonObj;


        CharacterBase[] playerArray;
        int playerCount = 0;
        if (jsonObjaux.HasField("Personaje"))

            playerCount = jsonObjaux.GetField("Personaje").Count;

        playerArray = new CharacterBase[playerCount];

        for (int i = 0; i < playerCount; i++)
        {
            //vuelvo al original y entro a los personajes
            jsonObjaux = jsonObj.GetField("Personaje"); //esto me devuelve una lista de personajes
            //YA DEBEN CREAR EL ARRAY DE OBJETOS PERSONAJE
            playerArray[i] = new CharacterBase();
            playerArray[i]._name = (jsonObjaux[i].HasField("name")) ? jsonObjaux[i].GetField("name").str : string.Empty; //en estos casos uso el indice i para acceder al nombre de cada uno de los personajes de la lista
            playerArray[i].desc = (jsonObjaux[i].HasField("descripcion")) ? jsonObjaux[i].GetField("descripcion").str : string.Empty;
            playerArray[i].type = (jsonObjaux[i].HasField("type")) ? (CharacterBase.characterType)(System.Enum.Parse(typeof(CharacterBase.characterType), (jsonObjaux[i].GetField("type").str))) : CharacterBase.characterType.ERROR;

            if (jsonObjaux[i].HasField("Stats"))
            {
                jsonObjaux = jsonObjaux[i].GetField("Stats"); //aca convierto mi Aux en los stats del personaje indice i
                playerArray[i].playerStats.ataque = (jsonObjaux.HasField("Ataque")) ? jsonObjaux.GetField("Ataque").n : 0; //es por eso que aca ya no uso el indice i para el jsonObjectAux
                playerArray[i].playerStats.defensa = (jsonObjaux.HasField("Defensa")) ? jsonObjaux.GetField("Defensa").n : 0;
                playerArray[i].playerStats.level = (jsonObjaux.HasField("Level")) ? jsonObjaux.GetField("Level").n : 0;
                playerArray[i].playerStats.destreza = (jsonObjaux.HasField("Destreza")) ? jsonObjaux.GetField("Destreza").n : 0;
                playerArray[i].playerStats.staminaCAP = (jsonObjaux.HasField("Stamina")) ? jsonObjaux.GetField("Stamina").n : 0;
                playerArray[i].playerStats.manaCAP = (jsonObjaux.HasField("Mana")) ? jsonObjaux.GetField("Mana").n : 0;
                playerArray[i].playerStats.vidaCAP = (jsonObjaux.HasField("Vida")) ? jsonObjaux.GetField("Vida").n : 0;
                playerArray[i].playerStats.xp = (jsonObjaux.HasField("xp")) ? jsonObjaux.GetField("xp").n : 0;
                playerArray[i].playerStats.speed = (jsonObjaux.HasField("Speed")) ? jsonObjaux.GetField("Speed").n : 0;

            }
        }

        return playerArray;
    }
}
