function iterativeFactorial(n: number): number {
    let fac = 1
    for (let i = 2; i <= n; i++) {
        fac = fac * i
    }
    return fac
}
// console.log(iterativeFactorial(0)) //1
// console.log(iterativeFactorial(5)) //120

function recusiveFactorial(n: number): number {
    if (n < 2)
        return 1
    return n * recusiveFactorial(n - 1)
}
// console.log(recusiveFactorial(0)) //1
// console.log(recusiveFactorial(5)) //120

function iterativeFibonacci(n: number): number { // 0 1 1 2 3 5 7
    let arr = [0, 1]
    for (let i = 2; i <= n; i++) {
        let fibo = arr[i - 1] + arr[i - 2]
        arr.push(fibo)
    }
    return arr[n]
}

// iterativeFibonacci(7) //13
//n=0;  arr[0,1]
//n=1;  arr[0,1]
//n=2;  arr[0, 1, 1]          //fibo = [i-1] + [i-2] = [1] + [0] = 1 + 0 = 1 // push(1)
//n=3;  arr[0, 1, 1, 2]       //fibo = [i-1] + [i-2] = [3-1] + [3-2] = [2] + [1] = 1 + 1 = 2 //push(2)
//n=4;  arr[0, 1, 1, 2, 3]                //fibo = [i-1] + [i-2] = [3] + [2] = 2 + 1 = 3 // push(3)
//n=5;  arr[0, 1, 1, 2, 3, 5] //fibo = [i-1] + [i-2] = [5-1] + [5-2] = [4] + [3] = 3 + 2 = 5 // push(5)
//n=6;  arr[0, 1, 1, 2, 3, 5, 8]         //fibo = [i-1] + [i-2] = [6-1] + [6-2] = [5] + [4] =  5 + 3 = 8 // push(8)     
//n=7;  arr[0, 1, 1, 2, 3, 5, 8, 13]  //fibo = [i-1] + [i-2] = [7-1] + [7-2] = [6] + [5] = 8 + 5 = 13 // push(13)
//return arr[7] == 13

// console.log(iterativeFibonacci(1))//1
// console.log(iterativeFibonacci(5))//5
// console.log(iterativeFibonacci(10))//55
// console.log(iterativeFibonacci(19))//4181
// console.log('------------------')

function recusiveFibonacci(n: number): number {
    if (n < 2)
        return n
    return recusiveFibonacci(n - 1) + recusiveFibonacci(n - 2)
}
// console.log(recusiveFibonacci(5))//5
//3  + 2 = 5
// console.log(recusiveFibonacci(1))//1
// console.log(recusiveFibonacci(5))//5
// console.log(recusiveFibonacci(10))//55
// console.log(recusiveFibonacci(19))//4181


const t0 = performance.now()
console.log(iterativeFibonacci(40))// 7 | 30 = 4-5 ms
const t1 = performance.now()
console.log(`iterativeFibonacci(40) took ${t1 - t0} ms`)

const rt0 = performance.now()
console.log(recusiveFibonacci(40))// 7  = 4 ms , 30 = 12ms
const rt1 = performance.now()
console.log(`recusiveFibonacci(40) took ${rt1 - rt0} ms`)