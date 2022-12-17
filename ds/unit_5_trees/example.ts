class BinaryTreeNode {
    value: any
    left: null | BinaryTreeNode
    right: null | BinaryTreeNode

    constructor(value: any) {
        this.value = value
        this.left = null
        this.right = null
    }
}

class BinarySearchTree {
    root: null | BinaryTreeNode = null
    insert(value: any) {
        const newNode = new BinaryTreeNode(value)
        if (this.root === null)
            this.root = newNode
        else
            this.#insertNode(this.root, newNode)
    }
    #insertNode(currentNode: BinaryTreeNode, newNode: BinaryTreeNode) {
        if (newNode.value < currentNode.value) {
            if (currentNode.left === null)
                currentNode.left = newNode
            else
                this.#insertNode(currentNode.left, newNode)
        } else {
            if (currentNode.right === null)
                currentNode.right = newNode
            else
                this.#insertNode(currentNode.right, newNode)
        }
    }
    remove(value: any) {
        if (this.root === null)
            return null
        const [deleteNode, parentNode] = this.#searchDeleteNode(value, this.root, null)
        if (deleteNode === null)
            return null
        return this.#removeNode(deleteNode, parentNode)
    }
    #removeNode(deleteNode: BinaryTreeNode, parentNode: BinaryTreeNode | null) {
        //Option 1 ไม่มีด้านขวา
        if (deleteNode.right === null) {
            if (parentNode === null)
                this.root = deleteNode.left
            else {
                if (parentNode.value > deleteNode.value)
                    parentNode.left = deleteNode.left
                if (parentNode.value < deleteNode.value)
                    parentNode.right = deleteNode.left
            }
        }
        //Option 2 ด้านขวาของตัวที่เราจะลบ ไม่มีลูกด้านซ้าย
        else if (deleteNode.right.left === null) {
            deleteNode.right.left = deleteNode.left
            if (parentNode === null)
                this.root = deleteNode.right
            else {
                if (parentNode.value > deleteNode.value)
                    parentNode.left = deleteNode.right
                if (parentNode.value < deleteNode.value)
                    parentNode.right = deleteNode.right
            }
        }
        // option 3 ด้านขวาของตัวที่เราจะลบ มี ลูกด้านซ้าย
        else {
            let leftmost = deleteNode.right.left
            let leftmostParent = deleteNode.right
            while (leftmost.left !== null) {
                leftmostParent = leftmost
                leftmost = leftmost.left
            }
            leftmostParent.left = leftmost.right
            leftmost.left = deleteNode.left
            leftmost.right = deleteNode.right
            if (parentNode === null)
                this.root = leftmost
            else {
                if (parentNode.value > deleteNode.value)
                    parentNode.left = leftmost
                if (parentNode.value < deleteNode.value)
                    parentNode.right = leftmost
            }
        }
    }
    #searchDeleteNode(value: any, currentNode: BinaryTreeNode, parentNode: BinaryTreeNode | null): [null | BinaryTreeNode, null | BinaryTreeNode] {
        if (value < currentNode.value && currentNode.left !== null) {
            parentNode = currentNode
            currentNode = currentNode.left
            return this.#searchDeleteNode(value, currentNode, parentNode)
        } else if (value > currentNode.value && currentNode.right !== null) {
            parentNode = currentNode
            currentNode = currentNode.right
            return this.#searchDeleteNode(value, currentNode, parentNode)
        } else if (value === currentNode.value)
            return [currentNode, parentNode]
        return [null, null]
    }
    search(value: any) {
        if (this.root === null)
            return null
        else
            return this.#searchNode(this.root, value)
    }
    #searchNode(currentNode: BinaryTreeNode, value: any): null | BinaryTreeNode {
        if (value < currentNode.value && currentNode.left !== null)
            return this.#searchNode(currentNode.left, value)
        else if (value > currentNode.value && currentNode.right !== null)
            return this.#searchNode(currentNode.right, value)
        else if (value === currentNode.value)
            return currentNode
        return null
    }
}

const bst = new BinarySearchTree()
bst.insert(40)
bst.insert(60)
bst.insert(30)
bst.insert(25)
bst.insert(35)
bst.insert(45)
bst.insert(65)
bst.insert(64)
bst.insert(72)
bst.insert(69)
bst.insert(68)
bst.insert(66)

bst.remove(65)
const text = JSON.stringify(bst)
console.log(text)
// const n = bst.search(990)
// console.log(n)
