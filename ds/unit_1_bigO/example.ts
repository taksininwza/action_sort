console.log('hello typecript')
console.log('hello prayuth')

// O(1)
function first_number(_numbers: number[]) {
    return _numbers[0];
}

// O(n)
function challenge(_input: any) {
    let num = 99; //O(1)
    num = num * _input.length; //O(1)
    for (let index = 0; index < _input.length; index++) { //O(n)
        num++; //O(n)
    }
    return num; //O(1)
}

// O(n^2)
function xx(_number1: any[]) {
    for (let index = 0; index < _number1.length; index++) {
        let _num1 = _number1[index]
        for (let index = 0; index < _number1.length; index++) {
            let _num2 = _number1[index];
            console.log(`${_num1} x ${_num2} = ${_num1 * _num2}`)
        }
    }
}

// O(n^3)
function xxx(_number1: any[]) {
    for (let index = 0; index < _number1.length; index++) {
        let _num1 = _number1[index]
        for (let index = 0; index < _number1.length; index++) {
            let _num2 = _number1[index];
            for (let index = 0; index < _number1.length; index++) {
                let _num3 = _number1[index];
                console.log(`${_num1} x ${_num2} x ${_num3} = ${_num1 * _num2 * 3}`)
            }
        }
    }
}

// O(n!)
function n_fac(_n: number) {
    for (let index = 0; index < _n; index++) {
        n_fac(_n - 1)
    }
}

