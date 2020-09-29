/*

Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

Example:
Given a binary tree
          1
         / \
        2   3
       / \     
      4   5    
Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].

Note: The length of path between two nodes is represented by the number of edges between them.

*/

/**
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int x) { val = x; }
* }
*/
using System;
public class DiameterOfBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public int CalcDiameterOfBinaryTree(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        int lheight = Height(root.left);
        int rheight = Height(root.right);
        return Math.Max(Math.Max(CalcDiameterOfBinaryTree(root.left), CalcDiameterOfBinaryTree(root.right)), lheight + rheight);

    }

    public int Height(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        int lH = Height(root.left);
        int rH = Height(root.right);
        return lH < rH ? rH + 1 : lH + 1;
    }

    //another way
    int res = int.MinValue;
    public int DiameterOfBinaryTreee(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        Solve(root);
        return res - 1;
    }

    private int Solve(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        int leftHeight = Solve(root.left);
        int rightHeight = Solve(root.right);

        res = Math.Max(res, 1 + leftHeight + rightHeight);

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}