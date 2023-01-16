class BynaryNode {
    value: any
    left: BynaryNode | null = null
    right: BynaryNode | null = null
    constructor(value: any) {
        this.value = value
    }
}


class BinarySearchTree {
    root: BynaryNode | null = null

    insert(value: any) {
        const newNode = new BynaryNode(value)
        if (this.root === null)
            this.root = newNode
        else
            this.#insertNode(this.root, newNode)
    }
    #insertNode(currentNode: BynaryNode, newNode: BynaryNode) {
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
    #removeNode(deleteNode: BynaryNode, parentNode: BynaryNode | null) {
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
    #searchDeleteNode(value: any, currentNode: BynaryNode, parentNode: BynaryNode | null): [null | BynaryNode, null | BynaryNode] {
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
    #searchNode(currentNode: BynaryNode, value: any): null | BynaryNode {
        if (value < currentNode.value && currentNode.left !== null)
            return this.#searchNode(currentNode.left, value)
        else if (value > currentNode.value && currentNode.right !== null)
            return this.#searchNode(currentNode.right, value)
        else if (value === currentNode.value)
            return currentNode
        return null
    }

    breadthFirstSearch() {
        if (this.root === null)
            return null
        let currentNode = this.root
        let bfs = []
        let queue = []
        queue.push(currentNode)
        while (queue.length > 0) {
            currentNode = queue.shift()!
            bfs.push(currentNode.value)
            if (currentNode.left !== null)
                queue.push(currentNode.left)
            if (currentNode.right !== null)
                queue.push(currentNode.right)
        }
        return bfs
    }
    breadthFirstSearchRecusive(queue: any[] = [this.root], bfs: any[] = []): any[] | null {
        if (queue.length < 1)
            return bfs
        const currentNode = queue.shift()
        bfs.push(currentNode.value)
        if (currentNode.left !== null)
            queue.push(currentNode.left)
        if (currentNode.right !== null)
            queue.push(currentNode.right)
        return this.breadthFirstSearchRecusive(queue, bfs)
    }
}

function breadthFirstSearch(tree: BinarySearchTree) {
    function traverse(queue: any[], bfs: any[]): any[] | null {
        if (queue.length < 1)
            return bfs
        const currentNode = queue.shift()
        bfs.push(currentNode.value)
        if (currentNode.left !== null)
            queue.push(currentNode.left)
        if (currentNode.right !== null)
            queue.push(currentNode.right)
        return traverse(queue, bfs)
    }

    return traverse([tree.root], [])
}

const bst = new BinarySearchTree()
bst.insert(40)
bst.insert(50)
bst.insert(30)
bst.insert(25)
bst.insert(35)
bst.insert(45)
bst.insert(60)
//const bfs = bst.breadthFirstSearch()
// const bfs = breadthFirstSearch(bst)
const bfs = bst.breadthFirstSearchRecusive()
console.log(bfs)
