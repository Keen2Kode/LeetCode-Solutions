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
    public int maxSum = int.MinValue;
    public int MaxPathSum(TreeNode root) {

        PathSum(root);
        return maxSum;
    }

    // just gets you the largest uninterrupted path sum.
    private int PathSum(TreeNode root) {
        if (root == null) {
            return 0;
        }
        // Console.WriteLine($"at node {root.val}");
        int leftSum = PathSum(root.left);
        int rightSum= PathSum(root.right);
        int subpathSum = leftSum + rightSum + root.val;

    
        // consider
        
        // left = a, root = b, right = c
        // max sum options = ab, bc, abc
        // Console.WriteLine($"left: {leftSum}, right: {rightSum}, subpathSum: {subpathSum}");
        
        leftSum += root.val;
        rightSum += root.val;
        
        maxSum = new int[]{leftSum, rightSum, subpathSum, maxSum}.Max();
        
        // you can only push ab, bc up.
        // abc = choosing subpath
               
        // what if a really low intermediary node makes sum<0? maybe reset sum to 0 before pushing
        int sumToPush = new int[]{leftSum, rightSum, 0}.Max();

        // Console.WriteLine($"maxSum: {maxSum}, sum to push: {sumToPush}");
        return sumToPush;
    }
}