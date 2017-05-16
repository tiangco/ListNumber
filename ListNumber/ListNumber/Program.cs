using ListNumber.Models;
using System;
using System.Collections.Generic;

namespace ListNumber {
	class Program {
		static void Main(string[] args) {

			try {
				ListNumberType ln = new ListNumberType("1>3>7");
			}
			catch (Exception ex) {
				Console.WriteLine($"Error encountered: {ex.Message}");
			}


			ListNumberType ln2 = new ListNumberType(1234);

			var x = new List<int>();
			x.Add(7);
			x.Add(8);
			x.Add(9);
			ListNumberType ln3 = new ListNumberType(x);

			var addResult = Add(ln3, ln2);
			Console.WriteLine(addResult);
			Console.ReadLine();
		}

		private static ListNumberType Add(ListNumberType lnA, ListNumberType lnB) {
			return lnA + lnB;
		}

		private static List<int> Add(List<int> list1, List<int> list2) {
			ListNumberType ln1 = new ListNumberType(list1);
			ListNumberType ln2 = new ListNumberType(list2);
			return (ln1 + ln2)._listNumber;
		}
	}
}
