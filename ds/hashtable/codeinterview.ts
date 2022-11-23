const array_1 = [2, 5, 1, 2, 3, 5, 1, 2, 4] // 2
const array_2 = [2, 1, 1, 3, 2, 5, 3, 7] // 1
const array_3 = [2, 4, 1, 7] //na

function bf(input: number[]) {
    let ans = undefined
    let nearestIndex = undefined
    for (let i = 0; i < input.length; i++) {
        for (let j = i + 1; j < input.length; j++) {
            if (input[i] === input[j] && (nearestIndex === undefined || nearestIndex > j)) {
                nearestIndex = j
                ans = input[i]
            }
        }
    }
    return ans
}


function ht(input: number[]) {
    let map = new Map()
    for (let i = 0; i < input.length; i++) { //O(n)
        if (map.get(input[i]) == undefined) {
            map.set(input[i], i)
        } else {
            return input[i]
        }
    }
}

const ans_1 = ht(array_1) //2
console.log(ans_1)
const ans_2 = ht(array_2) //1
console.log(ans_2)
const ans_3 = ht(array_3) //undefined
console.log(ans_3)