using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List <Items> itemArray;
    public GameObject itemButton;
    public Transform itemList;
    public GameObject Options;
    public GameObject inv;
    public Text _textName;
    public Text _textDesc;
    public Text _textType;
    public Text _textVida;
    public Text _textDefensa;
    public Text _textAtaque;
    public Text _textLevel;
    public Text _textDestreza;
    public Text _textMana;
    public Text _textStamina;
    public Text _textExperiencia;
    public Text _textSpeed;

    public Text _textItemName;
    public Text _textItemDesc;
    public Text _textItemVida;
    public Text _textItemDefensa;
    public Text _textItemAtaque;
    public Text _textItemAltura;
    public Text _textItemTiempo;
    public Text _textItemArmadura;

    [SerializeField] PlayerController _character;
    [SerializeField] int indexPlayer = 0;

    Items _item;
    public JsonManager json;

    
    private void Start()
    {
        //_character = (PlayerController)gameObject.AddComponent(typeof(PlayerController));
        _character.AddBaseInfo(json.GetPlayers()[indexPlayer]);
        itemArray = new List<Items>();

        for (int i = 0; i < json.GetItems().Length; i++)
        {
            itemArray.Add(json.GetItems()[i]);
        }

        _item = itemArray[0];
        ShowItemInfo(_item);
        ShowPlayerInfo(_character);
    }

    private void Open()
    {
        ShowItemInfo(_item);
        ShowPlayerInfo(_character);
        CrearBotones();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {            
            inv.SetActive(!inv.activeSelf);
            if(inv.activeSelf)
                Open();
            else
            {
                for (int i = 0; i < itemList.childCount; i++)
                {
                    Destroy(itemList.GetChild(i).gameObject);
                }
            }
        }
    }

    public void ShowPlayerInfo(PlayerController p_character)
    {
        if(p_character !=null)
        {
            _textName.text = p_character._name;
            _textDesc.text = p_character.desc;
            _textType.text = p_character.type.ToString();
		    _textVida.text = p_character.VidaCAPTot.ToString();
		    _textDefensa.text = p_character.DefensaTot.ToString();
		    _textAtaque.text = p_character.AtaqueTot.ToString();
		    _textLevel.text = p_character.LevelTot.ToString();
		    _textDestreza.text = p_character.DestrezaTot.ToString();
		    _textMana.text = p_character.ManaCAPTot.ToString();
		    _textStamina.text = p_character.StaminaCAPTot.ToString();
		    _textExperiencia.text = p_character.XPTot.ToString();
            _textSpeed.text = p_character.SpeedTot.ToString();
        }
    }
    public void ShowItemInfo(Items items)
    {
        if(items !=null)
        {
            _textItemName.text = items._name;
            _textItemDesc.text = items.desc;
            _textItemVida.text = items.itemStats.vidaCap.ToString();
            _textItemDefensa.text = items.itemStats.defensa.ToString();
            _textItemAtaque.text = items.itemStats.ataque.ToString();
            _textItemAltura.text = items.itemStats.altura.ToString();
            _textItemTiempo.text = items.itemStats.tiempo.ToString();
            _textItemArmadura.text = items.itemStats.armadura.ToString();
        }
    }

    public void UseItem(int index)
    {
        itemArray[index].Use(_character);
        ShowItemInfo(itemArray[index]);
    }

    public void ThrowItem(int index)
    {
        itemArray[index].Throw();
        if(itemArray[index].cantidad<=0)
        {
            itemArray.RemoveAt(index);
        }
    }
    public void CrearBotones()
    {
        for(int i = 0; i < itemArray.Count;i++)
        {
            GameObject create =  GameObject.Instantiate(itemButton);
            create.transform.SetParent(itemList);
            int localIndex = i;
            create.GetComponent<Button>().onClick.AddListener(() => { OptionsClick(localIndex); });
            create.GetComponentInChildren<Text>().text = itemArray[i]._name;
        }
    }
    int selectedItem;
    public void OptionsClick(int index)
    {
        Options.SetActive(true);
        ShowItemInfo(itemArray[index]);
        selectedItem = index;
    }
    public void OptionsUse()
    {
        UseItem(selectedItem);
        ShowPlayerInfo(_character);
        OptionsBack();
    }
    public void OptionsThrow()
    {
        ThrowItem(selectedItem);
        Destroy(itemList.GetChild(selectedItem).gameObject);
        OptionsBack();
    }
    public void OptionsBack()
    {
        for (int i = 0; i < itemList.childCount; i++)
        {
            Destroy(itemList.GetChild(i).gameObject);
        }
        Options.SetActive(false);
        Open();
    }
}

