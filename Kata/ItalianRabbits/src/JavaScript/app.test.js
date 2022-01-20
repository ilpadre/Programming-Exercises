const { rabbits, breedRabbits } = require('./app');


test('original pair is born', () =>{
    expect(breedRabbits(0)).toEqual(1)
})

test('original pair too young to breed pair', () => {
    expect(breedRabbits(1)).toEqual(1)
})

test('original pair has a pair', () => {
    expect(breedRabbits(2)).toEqual(2)
})

test('what the f', () => {
    expect(breedRabbits(6)).toEqual(13)
})

test('what the f', () => {
    expect(breedRabbits(11)).toEqual(144)
})