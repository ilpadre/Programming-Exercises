weatherFile = open("weather.dat.csv", "r")
next(weatherFile)

high = 0
low = 200
diff = 200
day = 0
for line in weatherFile:
    fields = line.split(",")
    thisHigh = int(fields[1])
    thisLow = int(fields[2])
    if diff > thisHigh - thisLow:
        diff = thisHigh - thisLow
        day = fields[0]

print(day)

