using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
	List<string> symbols = new List<string> { "ω", "Φ", "σ", "⋒", "ς", "₡", "☧", "℘", "ტ", " ჶ", "∑", "ໂ" };

	List<int> combination1;
	List<int> combination2;
	List<int> combination3;
	List<int> combination4;
	List<int> combination5;
	List<int> combination6;

	List<int> keypadSymbols = new();
	List<int> buttonPressOrder = new();

	public TextMeshPro keypadText;
	public List<KeypadButton> buttons;

	List<int> currentInputs = new();

	bool isDone = false;

	// Start is called before the first frame update
	void Start()
	{
		//the combinations are stored as the ids for the symbol string list
		combination1 = new List<int> { 0, 1, 7, 2, 8, 3 };
		combination2 = new List<int> { 4, 2, 9, 10, 3, 5 };
		combination3 = new List<int> { 9, 11, 1, 4, 7, 6 };
		combination4 = new List<int> { 3, 8, 0, 10, 5, 4 };
		combination5 = new List<int> { 1, 2, 0, 6, 9, 7 };
		combination6 = new List<int> { 11, 10, 9, 5, 6, 1 };

		List<List<int>> combinations = new List<List<int>>();
		combinations.Add(combination1);
		combinations.Add(combination2);
		combinations.Add(combination3);
		combinations.Add(combination4);
		combinations.Add(combination5);
		combinations.Add(combination6);

		List<int> combinationToUse = combinations[Random.Range(0, 6)];

		DetermineKeypadSymbols(combinationToUse);

		SetDisplayText("");
	}

	private void Update()
	{
		//for debugging without VR headset
		if (Input.GetKeyDown(KeyCode.Alpha1)) buttons[0].ButtonPressed();
		else if (Input.GetKeyDown(KeyCode.Alpha2)) buttons[1].ButtonPressed();
		else if (Input.GetKeyDown(KeyCode.Alpha3)) buttons[2].ButtonPressed();
		else if (Input.GetKeyDown(KeyCode.Alpha4)) buttons[3].ButtonPressed();
	}

	private void DetermineKeypadSymbols(List<int> combinationToUse)
	{
		Debug.Log("Using combination: " + string.Join(", ", combinationToUse));

		var tempList = new List<int>(combinationToUse);

		for (int i = 0; i < 4; i++)
		{
			int id = Random.Range(0, tempList.Count);
			keypadSymbols.Add(tempList[id]);
			tempList.RemoveAt(id);
		}

		SetButtonText();

		Debug.Log("Chosen keypad symbols: " + string.Join(", ", keypadSymbols));

		tempList = new List<int>(keypadSymbols);

		for (int i = 0; i < keypadSymbols.Count; i++)
		{
			int idOfLowest = tempList.IndexOf(tempList.Min());
			buttonPressOrder.Add(idOfLowest);
			tempList[idOfLowest] = 99; //setting this value to be some high number which is impossible to be the lowest in the list
		}

		Debug.Log("Keypad button order: " + string.Join(", ", buttonPressOrder));
	}

	private void SetButtonText()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			string symbol = symbols[keypadSymbols[i]];
			buttons[i].SetText(symbol, symbols.IndexOf(symbol));
		}
	}

	public void ButtonPressed(int buttonId, int symbolId)
	{
		if (isDone) return; //puzzle is already solved, don't do anything

		if(currentInputs.Count >= 4)
		{
			SetDisplayText("");
			currentInputs = new();
		}

		currentInputs.Add(buttonId);

		if (currentInputs.Count == 4)
		{
			CheckForCorrectCode();
		}
		else
		{
			AddToDisplayText(symbols[symbolId]);
		}
	}

	private void CheckForCorrectCode()
	{
		bool correct = true;
		for (int i = 0; i < currentInputs.Count; i++)
		{
			if (currentInputs[i] != buttonPressOrder[i]) correct = false;
		}

		if (correct)
		{
			isDone = true;
			SetDisplayText("CORRECT");
		}
		else
		{
			isDone = false;
			SetDisplayText("WRONG");
		}
	}

	void AddToDisplayText(string text)
	{
		keypadText.text += text;
	}

	void SetDisplayText(string text)
	{
		keypadText.text = text;
	}
}
