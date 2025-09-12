public class Solution {

    private Dictionary<char, string> mapping = Mapping();
    private List<string> combinations = new();
    private string digits;
    public IList<string> LetterCombinations(string digits) {
        this.digits = digits;

        if (digits == "" || digits == null) {
            return combinations;
        }

        
        NaryTree("",0);
        return combinations;
    }

private void NaryTree(string combo, int i) {
    if (i==digits.Length) {
        combinations.Add(combo);
        return;
    }
    // eg: i=0, digits= 23, mapping[2] = abc
    string options = mapping[digits[i]];
    foreach (char option in options) {
        NaryTree(combo + option, i+1);
    }
    
}
    
    private static Dictionary<char, string> Mapping(){
        Dictionary<char, string> mapping= new();
        mapping['2'] = "abc";
        mapping['3'] = "def";
        mapping['4'] = "ghi";
        mapping['5'] = "jkl";
        mapping['6'] = "mno";
        mapping['7'] = "pqrs";
        mapping['8'] = "tuv";
        mapping['9'] = "wxyz";

        return mapping;
    }
}