    using System;
    using System.Text;
     
    public class Test
    {
    	public static void Main()
    	{
    		//http://www.geeksforgeeks.org/find-the-minimum-element-in-a-binary-search-tree/
    		//http://cslibrary.stanford.edu/110/BinaryTrees.html
    		
    			/* Let us create following BST
    	              50
    	           /     \
    	          30      70
    	         /  \    /  \
    	       20   40  60   80 
    	    */
    		var bsTree = CreateBinarySearchTree();
    		Console.WriteLine("Minimum Value in Tree - {0}",bsTree.FindMinValue());
    		Console.WriteLine("Maximum Value in Tree - {0}",bsTree.FindMaxValue());
    	}
     
    	private static BinarySearchTree CreateBinarySearchTree()
    	{
    		//http://geeksquiz.com/binary-search-tree-set-1-search-and-insertion/
    		/*
    		Binary Search Tree, is a node-based binary tree data structure which has the following properties:
     
        		The left subtree of a node contains only nodes with keys less than the node’s key.
        		The right subtree of a node contains only nodes with keys greater than the node’s key.
        		The left and right subtree each must also be a binary search tree.
        		There must be no duplicate nodes.
    		*/
     
    		var bsTree = new BinarySearchTree();
    		/* Let us create following BST
    	              50
    	           /     \
    	          30      70
    	         /  \    /  \
    	       20   40  60   80 
    	    */
            bsTree.Insert(50);
            bsTree.Insert(50);
            bsTree.Insert(20);
            bsTree.Insert(40);
            bsTree.Insert(70);
            bsTree.Insert(60);
            bsTree.Insert(80);
            // print inorder traversal of the BST
            bsTree.PrintInOrder();
     
            return bsTree;
    	}
    }
    /* Class containing left and right child of current node and key value*/
    public class Node
    	{
    		public Node Left { get; set; }
    		public Node Right { get; set; }
     
    		public int Data { get; set; }
     
    		public Node()
    		{
    			Left = null;
    			Right = null;
    		}
     
    		public Node(int data) : this()
    		{
    			this.Data = data;
    		}
    	}
     
    public class BinarySearchTree
    {
    	private StringBuilder nodes;
    	public Node Root { get; private set;}
     
    	public BinarySearchTree()
    	{
    		nodes = new StringBuilder();
    		Root = null;
    	}
     
    	public void Insert(int data)
    	{
    		//Calls Insert Recusrisively
    		Root = InsertRecursive(Root, data);
    	}
     
    	//* A recursive function to insert a new key in BST */
    	private Node InsertRecursive(Node node, int data)
    	{
    		/* If the tree is empty, return a new node */
    		if(null == node)
    		{
    			var newNode = new Node(data);
    			node = newNode;
    			return node;
    		}
     
    		/* Otherwise, recur down the tree */
    		if(data <  node.Data)
    			node.Left = InsertRecursive(node.Left, data);
    		else
    			node.Right = InsertRecursive(node.Right, data);
     
    		/* return the (unchanged) node pointer */	
    		return node;	
    	}
     
    	public void PrintInOrder()
    	{
    		InOrderTRaversal(Root);
    		Console.WriteLine("TreeNode(InOrder): -> {0}",nodes.ToString());
    	}
     
    	// A utility function to do inorder traversal of BST
    	private void InOrderTRaversal(Node node)
    	{
    		if(null == node)
    		{
    			return;
    		}
     
    		InOrderTRaversal(node.Left);
    		//Console.WriteLine(node.Data);
    	 	nodes.Append(node.Data);
    	 	nodes.Append(" ");
    		InOrderTRaversal(node.Right);
    	}
     
    	// Recursive function to search a given key in a given BST
    	public Node Search(Node node, int key)
    	{
    		 // Base Cases: root is null or key is present at root
    		if(null == node || node.Data == key)
    		{
    			return node;
    		}
     
    		// Key is smaller than root's key
    		if(key < node.Data)
    		{
    			return Search(node.Left, key);
    		}
    		// Key is greater than root's key
    		return Search(node.Right, key);
    	}
    	
    	/* Given a non-empty binary search tree,  
		return the minimum data value found in that 
		tree. Note that the entire tree does not need 
		to be searched. */
    	public int FindMinValue()
    	{
    		var tempNode = Root;
    		while(null != tempNode.Left)
    		{
    			tempNode = tempNode.Left;
    		}
    		
    		return tempNode.Data;
    	}
    	
    	public int FindMaxValue()
    	{
    		var tempNode = Root;
    		while(null != tempNode.Right)
    		{
    			tempNode = tempNode.Right;
    		}
    		
    		return tempNode.Data;
    	}
    }
