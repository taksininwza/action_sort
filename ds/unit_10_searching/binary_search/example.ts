const numbers = [0, 1, 2, 50, 75, 98, 103, 112, 178, 203,];

function binarySearch(arr: number[], search: number) {
    let leftIndex = 0
    let rightIndex = arr.length - 1
    while (leftIndex <= rightIndex) {
        let midIndex = Math.floor((leftIndex + rightIndex) / 2)
        if (arr[midIndex] === search) {
            103 === 103
            return midIndex
        } else if (arr[midIndex] < search) {
            leftIndex = midIndex + 1
        } else {
            rightIndex = midIndex - 1
        }
    }
    return -1;
}

const search = binarySearch(numbers, 103);
console.log(search);