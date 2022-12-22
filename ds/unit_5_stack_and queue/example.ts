class StackArray {
    array = new Array
    peek() {
        return this.array[this.array.length - 1]
    }
    push(value: any) {
        this.array.push(value)
        return this
    }
    pop() {
        this.array.pop()
        return this
    }
}


class StackNode {
    value: any
    next: StackNode | null
    constructor(value: any) {
        this.value = value
        this.next = null
    }
}

class Stack {
    top: StackNode | null
    bottom: StackNode | null
    length: number
    constructor() {
        this.top = null
        this.bottom = null
        this.length = 0
    }
    peek() {
        return this.top
    }

    push(value: any) {
        const newNode = new StackNode(value)
        if (this.top === null) {
            this.top = newNode
            this.bottom = newNode
        } else {
            const holding = this.top
            this.top = newNode
            this.top.next = holding
        }
        this.length++
        return this
    }

    pop() {
        if (this.top === null) {
            return null;
        }
        if (this.top === this.bottom) {
            this.bottom = null
        }
        this.top = this.top!.next
        this.length--
        return this
    }

}


class QueueNode {
    value: any
    next: QueueNode | null
    constructor(value: any) {
        this.value = value
        this.next = null
    }
}

class Queue {
    first: QueueNode | null = null
    last: QueueNode | null = null
    length: number = 0

    peek() {
        return this.first?.value
    }

    enqueue(value: any) {
        const newNode = new QueueNode(value)
        if (this.first === null) {
            this.first = newNode
            this.last = newNode
        } else {
            this.last!.next = newNode
            this.last = newNode
        }
        this.length++
        return this
    }

    dequeue() {
        if (this.length === 0)
            return null
        if (this.first === this.last) {
            this.last = null
        }
        this.first = this.first!.next
        this.length--
        return this
    }
}

const myQueue = new Queue()
myQueue.enqueue(1)
myQueue.enqueue(2)
myQueue.enqueue(3)
myQueue.dequeue()
console.log(myQueue.peek())