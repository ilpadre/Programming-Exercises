import math
import mmh3
from bitarray import bitarray
  
  
class BloomFilter(object):

    def __init__(self, size):            
        '''
        items_count : int
            Number of items expected to be stored in bloom filter
        fp_prob : float
            False Positive probability in decimal
        '''

        # Size of bit array to use
        self.size = size

        # Bit array of given size
        self.bit_array = bitarray(self.size)

        # initialize all bits as 0
        self.bit_array.setall(0)

        # create array to store added words
        self.word_array = []

    def add(self, word):
        '''
        Add an item in the filter and to the word array
        '''

        self.word_array.append(word)
        self.bit_array[self.h1(word, self.size)] = True
        self.bit_array[self.h2(word)] = True
        self.bit_array[self.h3(word)] = True
        print(f'Added word: {word}')
        print(f'Bitarray is now: {self.bit_array}')
 
    def check(self, word):
        '''
        Check for existence of an item in filter
        '''

        if (self.bit_array[self.h1(word, self.size)] == False)  or (self.bit_array[self.h2(word)] == False) or (self.bit_array[self.h3(word)] == False):
            return False
        return True
    
    def h1(self, str, size):
        return self.str2int(str) % size

    def h2(self, word):
        A = 0.357840    
        hash = math.floor(self.size*((self.str2int(word) * A) % 1))
        return hash

    def h3(self, word):
        hash = mmh3.hash(word)
        return 9

    def str2int(self, str):
        sum = 0
        for c in str:
            sum += ord(c) - 96
        return sum
    
    def printWordList(self):
        print(self.word_array)


filterSize = 43
bloomf = BloomFilter(filterSize)
#print(bloomf.h3("moose"))
print(bloomf.add('moose'))
print(bloomf.add('cow'))
print(bloomf.add('elk'))
print(bloomf.add('steer'))
print(bloomf.add('hippopotamus'))
print(bloomf.add('wombat'))
print(bloomf.add('deer'))
print(bloomf.check('deer'))
print(bloomf.check('bull'))
print(bloomf.bit_array)

bloomf.printWordList()