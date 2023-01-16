let count = 0

function recursiveFibonacci(n: number): number {
    count++
    if (n < 2)
        return n
    return recursiveFibonacci(n - 1) + recursiveFibonacci(n - 2)
}

function dynamicFibonacci() {
    interface NumberArray {
        [index: number]: number
    }
    let cache: NumberArray = {}
    return function fibonacci(n: number): number {
        if (n in cache) {
            return cache[n]
        }
        count++
        if (n < 2)
            return n
        cache[n] = fibonacci(n - 1) + fibonacci(n - 2)
        return cache[n]
    }
}

let target = 3

count = 0
let value = recursiveFibonacci(target)
console.log(`recursiveFibonacci(${target}) = ${value} , count: ${count}`)

count = 0
const memoizedFibo = dynamicFibonacci()
value = memoizedFibo(target)
console.log(`memoizedFibo(${target}) = ${value} , count: ${count}`)