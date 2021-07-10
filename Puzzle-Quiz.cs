using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Input Puzzle Range With Split -");
		Console.WriteLine("Your Puzzel Input Is : 206938-679128");
		//String n = Convert.ToString(Console.ReadLine());
		String n = "206938-679128";
		
		string[] numbersInput = n.Split('-');
		
		int fromNumber = Convert.ToInt32(numbersInput[0]);
		int endNumber = Convert.ToInt32(numbersInput[1]);
		char[] fromCharArr = numbersInput[0].ToCharArray();
		char[] endCharArr = numbersInput[1].ToCharArray();
		
		List<string> listNumber = new List<string>();
		//Console.WriteLine(Convert.ToInt32(fromCharArr[0].ToString()));
		//Console.WriteLine(Convert.ToInt32(endCharArr[0].ToString()));
		for(int i = Convert.ToInt32(fromCharArr[0].ToString());i<=Convert.ToInt32(endCharArr[0].ToString());i++){
			string[] numbers = { i.ToString() };
			var data = runningNumber(numbers, 1, endNumber);
			listNumber.AddRange(data);
		}
		
		Console.WriteLine("PART ONE :" + listNumber.ToArray().Length);
		//FOR PART TWO
		int counter = 0;
		foreach(var item in listNumber){
			List<String> texts = new List<String>();
			var arrCode = item.ToCharArray();
			bool status = false;
			
			var results = validateLargerGroup(1, arrCode, arrCode[1].ToString(), texts);
			//Console.WriteLine("Z");
			foreach(var result in results) {
				//Console.WriteLine(result);
				if(result.Length == 2 ) {
					status = true;
				}else{
					status = false;
				}
			}
			//Console.WriteLine(item + " Status : " + status);
			if(status){
				counter++;
			}
		}
		Console.WriteLine( "PART TWO : " + counter);
		//END FOR PART TWO
		//206938-679128
	}
	
	public static string[] runningNumber(string[] number, int currentLength, int maxRange)
	{
		List<string> listNumber = new List<string>();
		for(int i = 0; i < number.Length; i ++) {
			int currentDigit = Convert.ToInt32(number[i].ToCharArray()[(number[i].Length -1)].ToString());
			for(int j = currentDigit;j<=9;j++){
				if(Convert.ToInt32(number[i] + j.ToString()) > maxRange){
					break;
				}
				string code = number[i] + j.ToString();
				if(validatePair(code) || currentLength < 5) listNumber.Add(number[i] + j.ToString());
			} 
		}
		if(currentLength == 5){
			return listNumber.ToArray();
		}else{
			return runningNumber(listNumber.ToArray(), ++currentLength, maxRange);
		}
	}
	
	public static bool validatePair(string code){
		var arrCode = code.ToCharArray();
		//List<int> numbers = new List<int>();
		for(int i = 0;i < (arrCode.Length-1); i++){
			if(arrCode[i] == arrCode[i+1]){
				return true;
			}
		}
		return false;
	}
	
	
	public static string[] validateLargerGroup(int i, char[] arrCode, string text, List<String> texts){
		if(i < arrCode.Length){			
			if(arrCode[i] == arrCode[i-1]){
				text = text + arrCode[i];
				return validateLargerGroup(++i, arrCode, text, texts);
			}else{
				if(text.Length >= 2){
					if(!string.IsNullOrEmpty(text)) texts.Add(text);
				}
				text = arrCode[i].ToString();
				return validateLargerGroup(++i, arrCode, text, texts);
			}
		}else{
			if(arrCode[i-1] == arrCode[i-2]){
				if(!string.IsNullOrEmpty(text)) texts.Add(text);
			}
			return texts.ToArray();
		}
		
	}
}
