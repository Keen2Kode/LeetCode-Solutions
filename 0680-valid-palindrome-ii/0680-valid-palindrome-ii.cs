public class Solution {
    public bool ValidPalindrome(string s) {
        // consider even/odd palindromes
        // work outward in, you get 1 skip
        // if last 2 chars equal OR same index true
        // if run out of skips, false

        int a=0;
        int b=s.Length-1;

        bool canSkip = true;

        while (a<b) {
            if (s[a] == s[b]) {
                a++;
                b--;
            }
            else {
                if (canSkip) {
                    canSkip = false;
                    // // lookahead to see if next character COULD match
                    // // doesn't work as you need to lookahead till the end
                    // // eg: "lcuucul"
                    // // AKA full paldindrome check required
                    // if (s[a+1] == s[b]) {
                    //     a++;
                    // }
                    // else if (s[b-1] == s[a]) {
                    //     b--;
                    // }
                    // else return false;

                    if (isPalindrome(s, a+1, b) || isPalindrome(s, a, b-1)) {
                        return true;
                    }
                    else return false;
                    
                }
                else return false;
            
            }
        }
        return true;
    }

    bool isPalindrome(string s, int a, int b) {
        while (a<b) {
            if (s[a] == s[b]) {
                a++;
                b--;
            }
            else return false;
        }
        return true;
    }
}