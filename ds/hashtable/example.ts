class HashTable {
    datas: any[]

    constructor(size: number) {
        this.datas = new Array(size)
    }

    //set input
    set(key: string, value: any) {
        let index = this.#hashfunction(key)
        //no collision
        if (this.datas[index] === undefined) {
            this.datas[index] = []

        }
        //collision
        this.datas[index].push([key, value])
    }

    //get
    get(key: string) {
        let index = this.#hashfunction(key)
        const bucket = this.datas[index]
        if (bucket !== undefined) {
            for (let i = 0; i < bucket.length; i++) {
                const item = bucket[i]
                const item_key = item[0] // key
                if (key == item_key) {
                    const value = item[1]
                    return value
                }
            }
        }
        return undefined
    }

    //delete
    delete(key: string) {
        let index = this.#hashfunction(key)
        const bucket = this.datas[index]
        if (bucket !== undefined) {
            for (let i = 0; i < bucket.length; i++) {
                const item = bucket[i]
                const item_key = item[0] // key
                if (key === item_key) {
                    bucket.splice(item, 1)
                }
            }
        }
    }

    //hash function
    #hashfunction(key: string) {
        let hashValue = 0
        for (let index = 0; index < key.length; index++) {
            hashValue += (key.charCodeAt(index) * index + 1)
            hashValue = hashValue % this.datas.length
        }
        return hashValue
    }
}

const hashtableObj = new HashTable(2);
//console.log(hashtableObj.datas)
hashtableObj.set('prayuth', 'hello')
hashtableObj.set('xxxxx', 'helloxxxxx')
console.log(hashtableObj.datas)
hashtableObj.delete('prayuth')
console.log(hashtableObj.datas)
//const x = hashtableObj.get('prayuth')
//console.log(x)
