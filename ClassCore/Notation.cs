using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCore
{
	public enum Precedence
	{
		lparen, rparen, plus, minus, multiply, divide, mod, and, or, operand,
	}

	public class Notation
	{
		private static List<int> cal_stack = new List<int>();
		private static List<char> chr_stack = new List<char>();
		private static List<char> express = new List<char>();
		private static int chr_top;
		private static void cal_push(int tp)
		{
			chr_top++;
			cal_stack.Add(tp);
		}
		private static int cal_pop()
		{
			int value = cal_stack[chr_top];
			cal_stack.RemoveAt(chr_top--);
			return value;
		}
		private static void chr_push(char tp)
		{
			chr_top++;
			chr_stack.Add(tp);
		}
		private static char chr_pop()
		{
			char value = chr_stack[chr_top];
			chr_stack.RemoveAt(chr_top--);

			return value;
		}
		private static void PostFix(char[] str)
		{
			int str_count = 0;

			while (str_count + 1 < str.Length)
			{
				if (str[str_count] == '(')
				{
					chr_push(str[str_count]);
					str_count++;
				}
				else if (str[str_count] == ')')
				{
					while (chr_stack[chr_top] != '(')
					{
						express.Add(chr_pop());
						express.Add(' ');
					}
					chr_pop();
					str_count++;
				}
				else if (str[str_count] == '+' || str[str_count] == '-' || str[str_count] == '*' || str[str_count] == '/'
					|| str[str_count] == '%' || str[str_count] == '&' || str[str_count] == '|')
				{
					while (chr_top >= 0 && GetPriority(chr_stack[chr_top]) >= GetPriority(str[str_count]))
					{
						express.Add(chr_pop());
						express.Add(' ');
					}
					chr_push(str[str_count]);
					str_count++;
				}
				else if ((str[str_count] >= '0' && str[str_count] <= '9') || (str[str_count] >= 'A' && str[str_count] <= 'Z') || str[str_count] == '_' || str[str_count] == '#')
				{
					do
					{
						express.Add(str[str_count++]);
					}
					while ((str[str_count] >= '0' && str[str_count] <= '9') || (str[str_count] >= 'A' && str[str_count] <= 'Z') || str[str_count] == '_' || str[str_count] == '#');
					express.Add(' ');
				}
				else
				{
					str_count++;
				}
			}

			while (chr_top >= 0)
			{
				express.Add(chr_pop());
				express.Add(' ');
			}
			express.RemoveAt(express.Count - 1);
		}
		private static int Calculation()
		{
			int fst_value;
			int scd_value;
			string str = "";
			foreach (char ch in express)
			{
				str += ch.ToString();
			}
			string[] tokenArray = str.Split(' ');

			foreach (string token in tokenArray)
			{
				if (GetToken(token) == Precedence.operand)
				{
					cal_push(int.Parse(token));
				}
				else
				{
					scd_value = cal_pop();
					fst_value = cal_pop();
					switch (GetToken(token))
					{
						case Precedence.plus: cal_push(fst_value + scd_value);
							break;
						case Precedence.minus: cal_push(fst_value - scd_value);
							break;
						case Precedence.multiply: cal_push(fst_value * scd_value);
							break;
						case Precedence.divide: cal_push(fst_value / scd_value);
							break;
						case Precedence.mod: cal_push(fst_value % scd_value);
							break;
						case Precedence.and: cal_push(fst_value & scd_value);
							break;
						case Precedence.or: cal_push(fst_value | scd_value);
							break;
					}
				}
			}
			return cal_pop();
		}
		private static Precedence GetToken(string str)
		{
			switch (str)
			{
				case "(":
					return Precedence.lparen;
				case ")":
					return Precedence.rparen;
				case "+":
					return Precedence.plus;
				case "-":
					return Precedence.minus;
				case "*":
					return Precedence.multiply;
				case "/":
					return Precedence.divide;
				case "%":
					return Precedence.mod;
				case "&":
					return Precedence.and;
				case "|":
					return Precedence.or;
			}
			return Precedence.operand;
		}
		private static int GetPriority(char op)
		{
			if (op == '(') return 0;
			if (op == '+' || op == '-') return 1;
			if (op == '*' || op == '/') return 2;
			if (op == '&' || op == '|') return 3;
			return 5;
		}

		public static string GetPostFix(string inFix)
		{
			try
			{
				cal_stack.Clear();
				chr_stack.Clear();
				express.Clear();
				chr_top = -1;

				string input = inFix.ToUpper().Trim() + " ";
				char[] chars = input.ToCharArray();

				PostFix(chars);

				string result = "";
				foreach (char ch in express)
				{
					result += ch.ToString();
				}

				return result;
			}
			catch
			{
				return null;
			}
		}
		public static string CalculatePostFix(string[] postFix)
		{
			try
			{
				cal_stack.Clear();
				chr_stack.Clear();
				express.Clear();
				chr_top = -1;

				int fst_value;
				int scd_value;

				foreach (string token in postFix)
				{
					if (GetToken(token) == Precedence.operand)
					{
						cal_push(int.Parse(token));
					}
					else
					{
						scd_value = cal_pop();
						fst_value = cal_pop();
						switch (GetToken(token))
						{
							case Precedence.plus: cal_push(fst_value + scd_value);
								break;
							case Precedence.minus: cal_push(fst_value - scd_value);
								break;
							case Precedence.multiply: cal_push(fst_value * scd_value);
								break;
							case Precedence.divide: cal_push(fst_value / scd_value);
								break;
							case Precedence.mod: cal_push(fst_value % scd_value);
								break;
							case Precedence.and: cal_push(fst_value & scd_value);
								break;
							case Precedence.or: cal_push(fst_value | scd_value);
								break;
						}
					}
				}
				return cal_pop().ToString();
			}
			catch
			{
				return null;
			}
		}
	}
}
