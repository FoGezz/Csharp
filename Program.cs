/*
My friend John and I are members of the "Fat to Fit Club (FFC)". John is worried because each month a list with the weights of members is published and each month he is the last on the list which means he is the heaviest.

I am the one who establishes the list so I told him: "Don't worry any more, I will modify the order of the list". It was decided to attribute a "weight" to numbers. The weight of a number will be from now on the sum of its digits.

For example 99 will have "weight" 18, 100 will have "weight" 1 so in the list 100 will come before 99. Given a string with the weights of FFC members in normal order can you give this string ordered by "weights" of these numbers?

Example:
"56 65 74 100 99 68 86 180 90" ordered by numbers weights becomes: "100 180 90 56 65 74 68 86 99"

When two numbers have the same "weight", let us class them as if they were strings and not numbers: 100 is before 180 because its "weight" (1) is less than the one of 180 (9) and 180 is before 90 since, having the same "weight" (9), it comes before as a string.

All numbers in the list are positive numbers and the list can be empty.
 */


using System;
using System.Collections.Generic;
using System.Linq;

public class WeightSort {
	
    public static int Main(string[] args) {
        Console.WriteLine(orderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
        return 0;
    }

    private static int countSum(string input) {
        int sum = 0;
        foreach(char c in input) {
            sum += (int)Char.GetNumericValue(c);
        }
        return sum;
    }

    struct Number {
        public uint Order, Real, Summed;
    }

	public static string orderWeight(string strng) {
		string[] splittedstring = strng.Split(' ');
        List<Number> NumList = new List<Number>();
        uint i = 1;
        foreach(string el in splittedstring)
        {
            Number num = new Number();
            num.Order = i;
            num.Real = Convert.ToUInt32(el);
            num.Summed = (uint)countSum(el);
            i++;
            NumList.Add(num);
        }
        var sortedDict = from entry in NumList orderby entry.Summed ascending select entry;
        for(i = 0; i < sortedDict.ToList().Count() - 1; i++) {
            var This = sortedDict.ElementAt((int)i);
            var That = sortedDict.ElementAt((int)++i);
            if(This.Summed == That.Summed) {
                if(This.Order < That.Order) {
                }
                else {
                    var temp = That;
                    That.Real = This.Real;
                    That.Order = This.Order;
                    This.Real = temp.Real;
                    This.Order = temp.Order;
                    --i;
                }
            }
        }
        string result = "";
        for(int j = 0; j < sortedDict.Count(); j++) {
            if(j == 0) { 
                result += sortedDict.ElementAt(j).Real;
            }
            else {
                result = result + " " + sortedDict.ElementAt(j).Real;
            }
        }
        return result;
}
}