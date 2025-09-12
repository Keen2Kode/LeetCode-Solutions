/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {

    private TreeNode p;
    private TreeNode q;
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        this.p = p;
        this.q = q;

        return LCA(root);
    }

    private TreeNode LCA(TreeNode node) {
        if (node == null)
            return null;
        if (node == p)
            return p;
        if (node == q)
            return q;


        TreeNode left = LCA(node.left);
        TreeNode right = LCA(node.right);
        // first parent of both
        if (left != null && right != null)
            return node;
        // only parent of 1
        return left ?? right;

    }


}