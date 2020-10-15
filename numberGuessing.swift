var choices: [Int] = []
var end = false 
while !end { 
    print("Minimum Number (Default - 1)", terminator: ": ") 
    var rangeMinInput = readLine()
    print("Maximum Number (Default - 100)", terminator: ": ")
    var rangeMaxInput = readLine()
    var rangeMin = Int()
    var rangeMax = Int()
    if Int(rangeMinInput!) != nil && Int(rangeMaxInput!) != nil && rangeMaxInput != nil && rangeMinInput != nil {
        if Int(rangeMinInput!) == Int(rangeMaxInput!) {
            rangeMinInput = nil 
            rangeMaxInput = nil 
            print("Maximum Number is equal to Minimum Number")
            print("Minimum Number is equal to Maximum Number")
            print("Numbers set to default") 
        } else if Int(rangeMinInput!)! > Int(rangeMaxInput!)! { 
            rangeMinInput = nil 
            rangeMaxInput = nil 
            print("Maximum Number is smaller than Minimum Number") 
            print("Minimum Number is greater than Maximum Number") 
            print("Numbers set to default") 
        }
    } else if Int(rangeMinInput!) != nil || Int(rangeMaxInput!) != nil || rangeMinInput?.isEmpty == true || rangeMaxInput?.isEmpty == true { 
        print("Either one or both characters/inputs are invalid")
        print("Invalid Character(s) set to default")
    } 
    
    if let rangeMinInput = rangeMinInput { 
        if rangeMinInput.isEmpty == true || Int(rangeMinInput) == nil { 
            rangeMin = 1 
        } else { 
            rangeMin = Int(rangeMinInput)! 
        } 
    } else { 
        rangeMin = 1 
    }   
    if let rangeMaxInput = rangeMaxInput { 
        if rangeMaxInput.isEmpty == true || Int(rangeMaxInput) == nil { 
            rangeMax = 100 
        } else { 
            rangeMax = Int(rangeMaxInput)! 
        } 
    } else { 
        rangeMax = 100 
    } 
    var tries = 0
    let numberToGuess = Int.random(in: rangeMin...rangeMax) 
    var foundCorrectNumber = false 
    while !foundCorrectNumber { 
        tries += 1 
        print("Guess a number from \(rangeMin) to \(rangeMax)", terminator: ": ") 
        let guessInput = readLine() 
        if !guessInput!.isEmpty { 
            if Int(guessInput!) != nil { 
                let guess = Int(guessInput!) 
                // print(guess) 
                // print(Number(guess)) 
                // print(choices) 
                // print(choices.contains(guess)) 
                if guess == numberToGuess { 
                    print("Congrats, you got it!") 
                    foundCorrectNumber = true 
                } else if (choices.contains(guess!)) { 
                    print("Number has been guessed before") 
                } else if (guess! > rangeMax || guess! < rangeMin) { 
                    print("Out of Range") 
                } else if (guess! > numberToGuess) { 
                    print("Sorry, guess again!\nNumber is Smaller") 
                } else if (guess! < numberToGuess) { 
                    print("Sorry, guess again!\nNumber is Larger") 
                } 
                choices.append(guess!) 
            } else { 
                print("Invalid Input") 
            } 
        } else { 
            print("Invalid Input") 
        } 
    } 
    print("The number was \(numberToGuess)") 
    if (tries > 1) { 
        print("You tried \(tries) times") 
    } else { 
        print("You tried 1 time") 
    } 
    print("Again [Y/N]", terminator: "? ") 
    let choice = readLine() 
    if choice!.lowercased().contains("n") || choice!.lowercased().contains("x") || Bool(choice!) == false { 
        end = true 
    } else if choice!.lowercased().contains("y") || Bool(choice!) == true { 
        end = false 
        print() 
        choices = [] 
    } else { 
        end = true 
    } 
}
