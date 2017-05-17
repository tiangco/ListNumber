using ListNumber.Models;
using System;
using System.Collections.Generic;

namespace ListNumber {
	class Program {
		static void Main(string[] args) {

			const string LISTOPERATOR_PARAMETER = "-operator:";
			const string OPERANDS_PARAMETER = "-operands:";

			bool isValid = true;
			string listOperator = string.Empty;
			ListNumberType lnA = new ListNumberType(string.Empty);
			ListNumberType lnB = new ListNumberType(string.Empty);

			foreach (string arg in args) {
				if (arg.StartsWith(LISTOPERATOR_PARAMETER, StringComparison.InvariantCultureIgnoreCase)) {
					listOperator = arg.ToLowerInvariant().Replace(LISTOPERATOR_PARAMETER, string.Empty).Trim();
					switch (listOperator) {
						case "+":
						case "add":
							listOperator = "add";
							break;
						case "*":
						case "mult":
						case "multiply":
							listOperator = "multiply";
							break;
						default:
							isValid = false;
							Console.WriteLine($"{LISTOPERATOR_PARAMETER} parameter '{listOperator}' is invalid. 'add' and 'multiply' are the valid values.");
							break;
					}
				}

				if (arg.StartsWith(OPERANDS_PARAMETER, StringComparison.InvariantCultureIgnoreCase)) {
					string listOperands = arg.ToLowerInvariant().Replace(OPERANDS_PARAMETER, string.Empty).Trim();
					string[] listArray = listOperands.Split(',');
					if (listArray.Length != 2) {
						isValid = false;
						Console.WriteLine($"{OPERANDS_PARAMETER} parameter '{listOperands}' is invalid. Valid example: 1->2,3->4");
					}
					else {
						GetOperand(out lnA, listArray[0], ref isValid);
						GetOperand(out lnB, listArray[1], ref isValid);
					}
				}
			}

			if (isValid && (lnA._listNumber.Count == 0 || lnB._listNumber.Count == 0)) {
				isValid = false;
				Console.WriteLine("-operands: is required.");
			}

			if (!isValid) {
				Console.WriteLine("Usage:");
				Console.WriteLine($" LineNumber {LISTOPERATOR_PARAMETER}(operator) {OPERANDS_PARAMETER}(operands)");
				Console.WriteLine($"       operator  Valid values are 'add' or 'multiply'.");
				Console.WriteLine($"       operands  Two lists separated by a comma. A list is of the format 'n[->n]...' where n is a digit from 0-9");
				Console.WriteLine();
				Console.WriteLine($"Example: LineNumber {LISTOPERATOR_PARAMETER}add {OPERANDS_PARAMETER}1->2->3,8->7");
			}
			else {
				switch (listOperator) {
					case "add":
						Console.WriteLine(lnA + lnB);
						break;
					case "multiply":
						Console.WriteLine(lnA * lnB);
						break;
					default:
						break;
				}

				switch (listOperator) {
					case "add":
						List<int> result = Add(lnA._listNumber, lnB._listNumber);
						ListNumberType ln = new ListNumberType(result);
						Console.WriteLine(ln);
						break;
					case "multiply":
						result = Multiply(lnA._listNumber, lnB._listNumber);
						ln = new ListNumberType(result);
						Console.WriteLine(ln);
						break;
					default:
						break;
				}
			}
			Console.WriteLine();
			Console.WriteLine("by Noel Tiangco. Press [Enter] to end.");
			Console.ReadLine();
		}

		// GetOperand(out lnA, listArray[0], isValid)
		private static void GetOperand(out ListNumberType ln, string representation, ref bool isValid) {
			try {
				ln = new ListNumberType(representation);
			}
			catch (Exception) {
				isValid = false;
				ln = new ListNumberType(string.Empty);
				Console.WriteLine($"operand {representation} is invalid. Valid example 1->2->3");
			}
		}

		private static ListNumberType Add(ListNumberType lnA, ListNumberType lnB) {
			return lnA + lnB;
		}

		private static ListNumberType Multiply(ListNumberType lnA, ListNumberType lnB) {
			return lnA * lnB;
		}


		private static List<int> Add(List<int> list1, List<int> list2) {
			ListNumberType ln1 = new ListNumberType(list1);
			ListNumberType ln2 = new ListNumberType(list2);
			return (ln1 + ln2)._listNumber;
		}

		private static List<int> Multiply(List<int> list1, List<int> list2) {
			ListNumberType ln1 = new ListNumberType(list1);
			ListNumberType ln2 = new ListNumberType(list2);
			return (ln1 * ln2)._listNumber;
		}

	}
}
