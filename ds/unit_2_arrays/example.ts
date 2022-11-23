class MyArray {
    length: number
    data: any//number
    constructor() {
        this.length = 0
        this.data = {}
    }
    get(index: number) { //O(1) //lookup/access
        return this.data[index] //1
    }
    push(value: any) { // 1+1 = O(2)  =>  O(1)
        this.data[this.length] = value; //1
        this.length++ //1
    }
    pop() { //1+1+1+1+1 = O(5) => O(1)
        if (this.length == 0) //1
            return
        this.length-- //1
        const item = this.data[this.length] //1
        delete this.data[this.length] //1
        return item //1
    }

    delete(index: number) {//O(n)
        if (index < 0 || index > this.length)
            return
        const item = this.data[index] //1
        this.shift(index)
        this.pop()
        return item
    }

    private shift(index: number) {
        for (let i = index; i < this.length - 1; i++) { // n
            this.data[i] = this.data[i + 1]
        }
    }
    insert(index: number, value: any) {
        this.push(value)
        for (let i = this.length - 1; i > index; i--) {
            const holding = this.data[i]
            this.data[i] = this.data[i - 1]
            this.data[i - 1] = holding
        }
        return this.length
    }
}

const myArray = new MyArray()
myArray.push(20)
myArray.push(30)
myArray.insert(1, 90)
console.log(myArray) //MyArray { length: 2, data: { '0': 20, '1': 90,'2':30 } }
myArray.push(50)
console.log(myArray)
console.log(myArray.get(0))//20
myArray.delete(1)//30
console.log(myArray)
myArray.pop()
console.log(myArray) 
