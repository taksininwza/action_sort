//index                 0       1          2        3       4       5           6       7           8
const solarSystem = ['Sun', 'Mercury', 'Venus', 'Earth', 'Mars', 'Jupiter', 'Saturn', 'Uranus', 'Neptune']

function linearSearch(arr: string[], search: string) {
    for (let index = 0; index < arr.length; index++) {
        if (arr[index] === search) {
            return index
        }
    }
    return -1
}

const search1 = linearSearch(solarSystem, "Mars")
console.log(search1)

const search2 = solarSystem.indexOf('Mars')
console.log(search2)

const search3 = solarSystem.findIndex((item) => item === 'Mars')
console.log(search3)

const search4 = solarSystem.find((item) => item === 'Mars')
console.log(search4)