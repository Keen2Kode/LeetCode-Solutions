/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<string> BinaryTreePaths(TreeNode root) {
        
        AddPath(root, new LinkedList<int>());
        return Stringified(paths);
    }

    private List<LinkedList<int>> paths = new List<LinkedList<int>>();
    private void AddPath(TreeNode node, LinkedList<int> path) {
        if (node == null)
            return;

        LinkedList<int> copy = new LinkedList<int>(path);
        copy.AddLast(node.val);

        bool isLeaf = (node.left == null && node.right == null);
        if (isLeaf) {
            paths.Add(copy);
            return;
        }
        AddPath(node.left, copy);
        AddPath(node.right, copy);
    }


    private IList<string> Stringified(List<LinkedList<int>> paths) {
        List<string> stringPaths = new List<string>();
        foreach (LinkedList<int> path in paths) {
            stringPaths.Add(string.Join("->",path));
        }
        return stringPaths;
    }

}