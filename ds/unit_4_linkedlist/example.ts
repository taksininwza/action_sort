class DoublyNode {
    data: any
    next: null | DoublyNode
    prev: null | DoublyNode
    constructor(data: any) {
        this.data = data
        this.next = null
        this.prev = null
    }
}

class DoublyLinkedList {
    head: DoublyNode | null
    tail: DoublyNode | null
    length: number

    constructor() {
        this.head = null
        this.tail = null
        this.length = 0
    }

    get(index: number) {
        if (index >= this.length)
            return null
        let counter = 0
        let currentNode = this.head
        while (counter < index) {
            currentNode = currentNode!.next
            counter++
        }
        return currentNode
    }

    toArray() {
        const array: any[] = []
        let node = this.head
        while (node !== null) {
            array.push(node!.data)
            node = node?.next
        }
        return array
    }
    remove(index: number) {
        if (this.head === null)
            return
        if (index >= this.length)
            return
        if (index < 1) {
            this.head = this.head.next
            this.head!.prev = null
            this.length--
            return
        }

        const deleteNode = this.get(index)
        if (deleteNode!.prev !== null) {
            deleteNode!.prev.next = deleteNode!.next
        }
        if (deleteNode!.next !== null) {//
            deleteNode!.next.prev = deleteNode!.prev
        } else {
            this.tail = deleteNode!.prev
        }

        this.length--
    }

    insert(index: number, data: any) {
        if (index >= this.length)
            this.append(data)
        if (index <= 0)
            this.appendLeft(data)
        const newNode = new DoublyNode(data)
        const leftNode = this.get(index - 1)
        //
        const rightNode = leftNode!.next
        leftNode!.next = newNode
        newNode!.prev = leftNode

        newNode!.next = rightNode
        rightNode!.prev = newNode
        //
        this.length++
        return newNode
    }

    appendLeft(data: any) {
        if (this.head === null) {
            this.append(data)
            return
        }
        const newNode = new DoublyNode(data)
        newNode.next = this.head
        this.head.prev = newNode
        this.head = newNode
    }

    append(data: any) {
        const newNode = new DoublyNode(data)
        if (this.head === null) {
            this.head = newNode
            this.tail = this.head
        } else {
            newNode.prev = this.tail
            this.tail!.next = newNode
            this.tail = newNode
        }
        this.length++
    }
}

let linkedList = new DoublyLinkedList()
linkedList.append(8)
linkedList.append(9)
linkedList.append(10)
linkedList.insert(1, 11)
linkedList.remove(1)
console.log(linkedList.toArray())
