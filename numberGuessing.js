function getRandomInt(min, max) {
  min = Math.ceil(min);
  max = Math.floor(max);
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

// function print(x){
//   console.log(x);
// }
// const print = console.log

var choices = [];

const prompt = require('prompt-sync')({sigint: true});

var end = false;

while (!end) {
  // console.log('Only Positive Integers Accepted');
  let rangeMin = prompt('Minimum Number (Default - 1): ');
  let rangeMax = prompt('Maximum Number (Default - 100): ');

  if (!isNaN(Number(rangeMin)) && !isNaN(Number(rangeMax)) && rangeMin && rangeMax && rangeMin.trim() && rangeMax.trim()){
    if (rangeMin == rangeMax) {
      rangeMin = null;
      rangeMax = null;
      console.log('Maximum Number is equal to Minimum Number');
      console.log('Minimum Number is equal to Maximum Number');
      console.log('Numbers set to default');
    } else if (rangeMin > rangeMax) {
      rangeMin = null;
      rangeMax = null;
      console.log('Maximum Number is smaller than Minimum Number');
      console.log('Minimum Number is greater than Maximum Number');
      console.log('Numbers set to default');
    } 
  } else if (isNaN(rangeMin) || isNaN(rangeMax) || !rangeMax || !rangeMin || !rangeMin.trim() || !rangeMax.trim()) {
    console.log('Either one or both characters/inputs are invalid');
    console.log('Invalid Character(s) set to default');
  }

  if (!rangeMin || isNaN(rangeMin) || !rangeMin.trim()) {
    rangeMin = 1;
  }
  if (!rangeMax || isNaN(rangeMax) || !rangeMax.trim()) {
    rangeMax = 100;
  }

  var tries = 0;
  // Random number from 1 - 10
  let numberToGuess = getRandomInt(rangeMin, rangeMax);
  // This variable is used to determine if the app should continue prompting the user for input
  let foundCorrectNumber = false;
  // console.log(numberToGuess);

  while (!foundCorrectNumber) {
    tries++;
    // Get user input
    var guess = prompt(`Guess a number from ${rangeMin} to ${rangeMax}: `);
    // Compare the guess to the secret answer and let the user know.
    if (guess) {
      // if (typeof Number(guess) === "number" || Number(guess) !== NaN || Number(guess) != NaN){\
      if (!isNaN(Number(guess)) && guess.trim().length != 0) {
        guess = Number(guess);
        // console.log(guess);
        // console.log(Number(guess));
        // console.log(choices);
        // console.log(choices.includes(guess));
        if (guess === numberToGuess || guess == numberToGuess) {
          console.log('Congrats, you got it!');
          foundCorrectNumber = true;
        } else if (choices.includes(guess)) {
          console.log('Number has been guessed before');
        } else if (guess > rangeMax || guess < rangeMin) {
          console.log('Out of Range');
        } else if (guess > numberToGuess) {
          console.log('Sorry, guess again!\nNumber is Smaller');
        } else if (guess < numberToGuess) {
          console.log('Sorry, guess again!\nNumber is Larger');
        } 
        choices.push(guess);
      } else {
        console.log('Invalid Input');
      }
    } else {
      console.log('Invalid Input');
    }
  }

  console.log(`The number was ${numberToGuess}`);
  
  if (tries > 1) {
    console.log(`You tried ${tries} times`);
  } else {
    console.log('You tried 1 time');
  }

  let choice = prompt('Again [Y/N]? ');
  if (choice.toLowerCase().includes('n') || choice.toLowerCase().includes('x') || Boolean(choice) == false) {
    end = true;
  } else if (choice.toLowerCase().includes('y') || Boolean(choice) == true) {
    end = false;
    console.log();
    choices = [];
  } else {
    end = true;
  }
}
