// Implement your exercise in this file.  If you need to implement additional functions,
// remember to export them as well, if you need to access them in your unit test.


let rabbits = []
const breedRabbits = (month) => {
    let rabbits = []
    rabbits[0]= 0
    for (let i = 0; i < month; i++) {
        let newborns = []
        for (let j = 0; j < rabbits.length; j++) {
            if (rabbits[j] === 0 ) {
                rabbits[j]=rabbits[j] + 1
            } else {
                newborns.push(0)
            }

        }
        let t = rabbits.concat(newborns)
        rabbits = t
    }
    return rabbits.length
}

console.log(breedRabbits(0)) // 1
console.log(breedRabbits(1)) // 1
console.log(breedRabbits(2)) // 2
console.log(breedRabbits(3)) // 3
console.log(breedRabbits(4)) // 5
console.log(breedRabbits(5)) // 8
console.log(breedRabbits(6)) // 13
console.log(breedRabbits(7)) // 21
console.log(breedRabbits(8)) // 34
console.log(breedRabbits(9)) // 55
console.log(breedRabbits(10)) // 89
console.log(breedRabbits(11)) // 144

module.exports = { rabbits, breedRabbits };