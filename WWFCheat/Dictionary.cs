using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WWFCheat
{
	public class Dictionary
	{
		private static List<string> master_dictionary;
		public static string user_input;
		public static string[] user_letters;
		public static List<Word> accepted_words;
		public static int blank_tiles;
		private static Dictionary<char, int> letter_values;

		public struct Word{
			public Word(string Value, int Point_Value){
				value = Value;
				point_value = Point_Value;
			}
			public int point_value;
			public string value;
		}

		/*
		 * When instatiated, the constructor will load the entries into the dictionary and load the letter values
		 */ 
		public Dictionary (string User_Input, int Blank_Tiles)
		{
			master_dictionary = new List<string> ();
			int max_length = 0;
			user_input = User_Input;
			blank_tiles = Blank_Tiles;
			accepted_words = new List<Word> ();
			letter_values = new Dictionary<char, int> ();
			user_letters = new string[User_Input.Count ()];
			Load_Dictionary ();
			Load_Letter_Values ();
		}

		/*
		 * This method will read through each line in Dictionary.txt and add the words into our master_dictionary list 
		 */
		private void Load_Dictionary(){
			try
			{
				using (StreamReader sr = new StreamReader(@"Dictionary.txt"))
				{
					string line;
					while((sr.ReadLine()) != null){
						line = sr.ReadLine(); 
						master_dictionary.Add(line);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
			}
		}

		/*
		 * This method will split the user's input on a comma and store the result in user_letters
		 */
		private static void Parse_UserInput(){
			char[] tmp = user_input.ToCharArray ();
			for (int i = 0; i < tmp.Count(); i++) {
				user_letters.SetValue(tmp [i].ToString (), i);
			}
		}

		/*
		 * This method will do the work of checking a single word from the dictionary and seeing if the letters that the user input can create it.
		 * 'Letter Overflow' signifies that the word in the dictionary has too many letters and cannot be created by the ones the user supplied.
		 * Returns true if Letter Overflow occurs, returns false otherwise.
		 */
		private static bool Check_LetterOverflow(string word){
			List<string> remaining_letters = new List<string> ();
			int remaining_blanks = blank_tiles;
			bool letter_overflow = false;
			char[] word_letters = word.ToCharArray();

			foreach (string s in user_letters) {
				remaining_letters.Add (s);
			}

			foreach (char s in word_letters) {
				if (remaining_letters.Contains (s.ToString ())) {
					remaining_letters.Remove (s.ToString ());
				} else if (remaining_letters.Count <= remaining_blanks && remaining_blanks > 0) {
					remaining_blanks--;
					continue;
				}
				else {
					letter_overflow = true;
					return letter_overflow;
				}
			}

			return letter_overflow;
		}

		/*
		 * This method will take an accepted word with no letter overflow and a corresponding point value, create a word struct and add it into the list of accepted words.
		 */ 
		private static void Add_Word(string word, int point_value){
			Word word_struct = new Word (word, point_value);
			accepted_words.Add (word_struct);
		}

		/*
		 * This is the method serves as a wrapper for all the work going on in the class.
		 * It will call Parse_UserInput() to set the user_letters and iterate through each word in the WWF dictionary to test it.
		 * Upon a successful test, the word will be assigned a point value via the Point_Word method and added to the accepted word list via the Add_Word method.
		 */ 
		public void Test_Input(){
			Parse_UserInput ();
			for(int i = 0; i < master_dictionary.Count-1; i++) {
				string word = master_dictionary.ElementAt (i);
				if (Check_LetterOverflow (word)) {
					continue;
				} else {
					int point_value = Point_Word (word);
					Add_Word (word, point_value);
				}
			}
		}

		/*
		 * This method will be called by the constructor to populate the dictionary with the appropriate values that will be used to point a word.
		 */ 
		private void Load_Letter_Values(){
			letter_values.Add ('a', 1);
			letter_values.Add ('b', 4);
			letter_values.Add ('c', 4);
			letter_values.Add ('d', 2);
			letter_values.Add ('e', 1);
			letter_values.Add ('f', 4);
			letter_values.Add ('g', 3);
			letter_values.Add ('h', 3);
			letter_values.Add ('i', 1);
			letter_values.Add ('j', 10);
			letter_values.Add ('k', 5);
			letter_values.Add ('l', 2);
			letter_values.Add ('m', 4);
			letter_values.Add ('n', 2);
			letter_values.Add ('o', 1);
			letter_values.Add ('p', 4);
			letter_values.Add ('q', 10);
			letter_values.Add ('r', 1);
			letter_values.Add ('s', 1);
			letter_values.Add ('t', 1);
			letter_values.Add ('u', 2);
			letter_values.Add ('v', 5);
			letter_values.Add ('w', 4);
			letter_values.Add ('x', 8);
			letter_values.Add ('y', 3);
			letter_values.Add ('z', 10);
		}

		/*
		 * This method will take an accepted word and assign a point value to it by breaking it down into a character array.
		 */ 
		private static int Point_Word(string word){
			char[] characters = word.ToCharArray();
			int value = 0;
			foreach (char character in characters) {
				value += letter_values [character];
			}
			return value;
		}

		/*
		 * This method will sort the list of accepted words by their point value and then use String.Format to format the results to display to the user. 
		 */
		public string Output_Words(){
			List<Word> SortedList = accepted_words.OrderByDescending(o=>o.point_value).ToList();
			string output = "";
			foreach (Word word in SortedList) {
				int num_spaces = 25 - word.value.Length;
				string spaces = "";
				for (int i = 0; i < num_spaces; i++) {
					spaces += " ";
				}
				string k = string.Format("{0}{1} \t \t {2}", word.value, spaces, word.point_value);
				output += k + Environment.NewLine;
			}
			return output;
		}

		/*
		 * Clears all information from previous uses.
		 */ 
		public void Reset(){
			user_input = null;
			user_letters = null;
			user_input = null;
			user_letters = null;
			accepted_words = null;
		}

	}
}