using System;
using System.Collections.Generic;
using System.Linq;

namespace ListNumber.Models {
	public struct ListNumberType {

		private int _value;
		public List<int> _listNumber;

		/// <summary>
		/// listString assumes the format 1->3->2->4, which represents a value of 4231"
		/// </summary>
		/// <param name="listString"></param>
		public ListNumberType(string listString) {
			try {
				string[] numberArray = listString.Split(new string[] { "->" }, StringSplitOptions.None);
				_listNumber = Array.ConvertAll(numberArray, Int32.Parse).ToList();

				Array.Reverse(numberArray);
				_value = int.Parse(string.Join(string.Empty, numberArray));
			}
			catch (Exception) {
				throw;
			}
		}

		public ListNumberType(int value) {
			try {
				_value = value;
				char[] valueArray = _value.ToString().ToArray();
				Array.Reverse(valueArray);
				_listNumber = Array.ConvertAll(valueArray, c => (int)Char.GetNumericValue(c)).ToList();
			}
			catch (Exception) {
				throw;
			}
		}

		public ListNumberType(List<int> listNumber) {
			try {
				_listNumber = listNumber;

				string[] numberArray = Array.ConvertAll(listNumber.ToArray(), c => c.ToString());
				Array.Reverse(numberArray);
				_value = int.Parse(string.Join(string.Empty, numberArray));

			}
			catch (Exception) {
				throw;
			}
		}

		public static ListNumberType operator +(ListNumberType ln1, ListNumberType ln2) {
			return new ListNumberType(ln1._value + ln2._value);
		}

		public static ListNumberType operator *(ListNumberType ln1, ListNumberType ln2) {
			return new ListNumberType(ln1._value * ln2._value);
		}

		public override string ToString() {
			return string.Join("=>", _listNumber);
		}

	}

}
