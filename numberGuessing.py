import random

choices = []

end = False

while not end:
  rangeMin = input('Minimum Number (Default - 1): ')
  rangeMax = input('Maximum Number (Default - 100): ')

  if rangeMin.lstrip("-").isnumeric()) and rangeMax.lstrip("-").isnumeric() and rangeMax and rangeMin:
    if rangeMin == rangeMax:
      rangeMin = None
      rangeMax = None
      print('Maximum Number is equal to Minimum Number')
      print('Minimum Number is equal to Maximum Number')
      print('Numbers set to default')
    elif rangeMin > rangeMax:
      rangeMin = None
      rangeMax = None
      print('Maximum Number is smaller than Minimum Number')
      print('Minimum Number is greater than Maximum Number')
      print('Numbers set to default')
  elif not rangeMin.lstrip("-").isnumeric()) or not rangeMax.lstrip("-").isnumeric() or (not rangeMax) or (not rangeMin):
    print('Either one or both characters/inputs are invalid')
    print('Invalid Character(s) set to default')
    
  if not rangeMin or not rangeMin.lstrip("-").isnumeric():
    rangeMin = 1
  
  if not rangeMax or not rangeMax.lstrip("-").isnumeric():
    rangeMax = 100
  
  tries = 0

  # Random number from 1 - 10
  numberToGuess = random.randint(int(rangeMin), int(rangeMax))
  # This variable is used to determine if the app should continue inputing the user for input
  foundCorrectNumber = False
  # print(numberToGuess)

  while not foundCorrectNumber:
    tries += 1
    # Get user input
    print("Guess a number from "+str(rangeMin)+" to "+str(rangeMax)+": ", end="")
    guess = input()

    # Compare the guess to the secret answer and the user know.
    if guess:
      # try:
      #   int(guess)
      # # if typeof Number(guess) === "number" or Number(guess) not == NaN or Number(guess) not = NaN){
      # except ValueError:
      if guess.lstrip("-").isnumeric():
        guess = int(guess)
        # print(guess)
        # print(Number(guess))
        # print(choices)
        # print(choices.includes(guess))
        if guess == numberToGuess:
          print('Congrats, you got it!')
          foundCorrectNumber = True
        elif guess in choices:
          print('Number has been guessed before')
        elif guess > int(rangeMax) or guess < int(rangeMin):
          print('Out of Range')
        elif guess > numberToGuess:
          print('Sorry, guess again\nNumber is Smaller')
        elif guess < numberToGuess:
          print('Sorry, guess again\nNumber is Larger')
        choices.append(guess)
      else:
        print('Invalid Input')
    else:
      print('Invalid Input')
  
  print("The number was", str(numberToGuess))
  
  if tries > 1:
    print("You tried "+ str(tries) +" times")
  else:
    print('You tried 1 time')
  

  choice = input('Again [Y/N]? ')
  if 'n' in choice.lower() or 'x' in choice.lower() or bool(choice) == False:
    end = True
  elif 'y' in choice.lower() or bool(choice) == True:
    end = False
    print()
    choices = []
  else:
    end = True
