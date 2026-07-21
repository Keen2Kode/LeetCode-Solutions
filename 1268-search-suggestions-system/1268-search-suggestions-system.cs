public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Array.Sort(products);
        // look for 'm'
        // then 'mo'
        string searchPrefix = "";
        IList<IList<string>> suggestedProducts = new List<IList<string>>();
        
        for (int i=0; i<searchWord.Length; i++) {
            searchPrefix += searchWord[i];
            List<string> suggested= new();
            foreach (string product in products) {
                if (product.StartsWith(searchPrefix) && suggested.Count < 3)
                    suggested.Add(product);
            }
            suggestedProducts.Add(suggested);
        }
        return suggestedProducts;
    }
}