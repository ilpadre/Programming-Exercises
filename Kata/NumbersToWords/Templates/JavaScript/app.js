const ones = [ "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ];
const teens = [ "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eightteen", "nineteen" ];
const tens = [ "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" ];

function numberToWords(value) {
    if (value < 0) {
        return "not supported";
    }

    if (value < 10) {
        return ones[value];
    }

    if (value < 20) {
        return teens[value - 10];
    }

    if (value < 10 ** 2) {
        return split(value, 10 ** 1, '', tensLookup);
    }

    if (value < 10 ** 3) {
        return split(value, 10 ** 2, "hundred");
    }

    if (value < 10 ** 6) {
        return split(value, 10 ** 3, "thousand");
    }

    if (value < 10 ** 9) {
        return split(value, 10 ** 6, "million");
    }

    return "too big"
}

function tensLookup(wholeUnits) {
    return tens[wholeUnits];
}

function split(value, divisor, units, lookup) {
    const wholeUnits = parseInt(value / divisor);
    const remainder = value % divisor;
    const prefix = lookup ? lookup(wholeUnits) : `${numberToWords(wholeUnits)} ${units}`;
    const suffix = (remainder > 0) ? ` ${numberToWords(remainder)}` : "";
    return prefix + suffix;
}


/*** Testing below ****/

function test(value, expectedResult) {
    const result = numberToWords(value);
    if (result == expectedResult) {
        console.log(`PASS: ${value}: ${result}`);
    } else {
        console.log(`*** FAIL: ${value}:`);
        console.log(`expected: ${expectedResult}`);
        console.log(`  actual: ${result}`);
    }
}

test(-1, "not supported");
test(0, "zero");
test(1, "one");
test(2, "two");
test(3, "three");
test(4, "four");
test(5, "five");
test(10, "ten");
test(11, "eleven");
test(20, "twenty");
test(21, "twenty one");
test(154, "one hundred fifty four");
test(200, "two hundred");
test(999, "nine hundred ninety nine");
test(2048, "two thousand forty eight");
test(12619, "twelve thousand six hundred nineteen");
test(380030, "three hundred eighty thousand thirty");
test(5241726, "five million two hundred forty one thousand seven hundred twenty six");
test(311616765, "three hundred eleven million six hundred sixteen thousand seven hundred sixty five");
test(9124762046, "too big");

module.exports = { numberToWords };