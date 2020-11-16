/*
https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST.

According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”

 

Example 1:


Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
Output: 6
Explanation: The LCA of nodes 2 and 8 is 6.
Example 2:


Input: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
Output: 2
Explanation: The LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.
Example 3:

Input: root = [2,1], p = 2, q = 1
Output: 2
 

Constraints:

The number of nodes in the tree is in the range [2, 105].
-109 <= Node.val <= 109
All Node.val are unique.
p != q
p and q will exist in the BST.
 */

public class LowestCommonAncestorofABST
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        int parentVal = root.val;
        int pVal = p.val;
        int qVal = q.val;

        if (qVal > parentVal && pVal > parentVal)
        {
            //Both p and q values are greater than the parent, then move to the right part of the tree.
            return LowestCommonAncestor(root.right, p, q);
        }
        else if (qVal < parentVal && pVal < parentVal)
        {
            //Both p and q values are less than the parent, then move to the left part of the tree.
            return LowestCommonAncestor(root.left, p, q);
        }
        else
        {
            //Now p and q will lie between the parent, return the parent which is root.
            return root;
        }
    }
}