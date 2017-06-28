Module roulette

    Sub Main()

        '1. Variables
        Dim color As String
        Dim ball As Integer
        Randomize()
        Dim choice As Integer
        Dim cash As Decimal
        Dim bet As Decimal
        Dim number As Integer
        Dim odds As Integer
        Dim wager As Integer
        Dim winner As Boolean

        '2. Menu: Introduction and choices...choices to remain on screen clear (art?)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(vbTab & vbTab & "Welcome to Last Chance Diner and Casino.")
        Console.WriteLine()
        Console.WriteLine(vbTab & vbTab & vbTab & "Menu or special order?")
        Console.WriteLine()
        Console.WriteLine(vbTab & vbTab & "     _____________ ______________ ")
        Console.WriteLine(vbTab & vbTab & "    (_,---------.(`______________`) ")
        Console.WriteLine(vbTab & vbTab & "                 \               / ")
        Console.WriteLine(vbTab & vbTab & "                  `-------------' ")
        Console.WriteLine()
        Console.WriteLine(vbTab & "Perhaps a game of roulette while you wait?")
        Console.WriteLine(vbTab & "100 dollars, on the house, while I cook your order.")

        cash = 100

        'roulette choices
        Console.WriteLine(vbTab & "Current Cash is: " & cash.ToString("C"))
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(vbTab & "Press 1 to play Red (1:1)")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(vbTab & "Press 2 to play Black (1:1)")
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine(vbTab & "Press 3 to play the First 12 (2:1)")
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.WriteLine(vbTab & "Press 4 to play the Middle 12(2:1)")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine(vbTab & "Press 5 to play the Last 12(2:1)")
        Console.ForegroundColor = ConsoleColor.DarkCyan
        Console.WriteLine(vbTab & "Press 6 to play any number (35:1)")
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(vbTab & "Press 7 to cash out and recieve your order")
        Console.Write(vbTab & "Enter gameplay choice: ")
        choice = getInteger()
        Console.WriteLine()

        'validation
        While choice < 0 Or choice > 7
            Console.WriteLine(vbTab & "Someday you're going to learn you can't make a joke about everything.")
            Console.Write(vbTab & "Enter gameplay choice: ")
            choice = getInteger()
            Console.WriteLine()
        End While

        'revolving roulette menu (current setup allows cash out but does not seem to acknowledge 0 cash)
        While choice <> 7 And cash > 0

            Console.Write(vbTab & "Enter bet amount: ")
            bet = getInteger()

            While bet < 0 Or bet > cash
                Console.WriteLine(vbTab & "Nice try, better luck next time.")
                Console.Write(vbTab & "Enter bet amount: ")
                bet = getInteger()
            End While

            If choice = 6 Then
                Console.Write(vbTab & "Enter roulette number: ")
                number = getInteger()

                While number < 0 Or number > 36
                    'ask about upper number!!!!
                    Console.WriteLine(vbTab & "Are you sure you want to bet on that number?")
                    Console.Write(vbTab & "Enter roulette number: ")
                    number = getInteger()
                End While
            End If

            Console.WriteLine(vbTab & "Press key to roll roulette ball.")
            Console.ReadKey(True)
            Console.WriteLine()

            '3. Roulette calculations (include validations for cash, choice, etc

            ball = Int(Rnd() * 37)

            If ball = 0 Then
                color = "Green"
            ElseIf ball Mod 2 = 0 Then
                color = "Black"
            Else
                color = "Red"
            End If

            winner = False

            If choice = 1 And color = "Red" Then
                winner = True
                odds = 1
            ElseIf choice = 2 And color = "Black" Then
                winner = True
                odds = 1
            ElseIf choice = 3 And ball >= 1 And ball <= 12 Then
                winner = True
                odds = 2
            ElseIf choice = 4 And ball > 12 And ball <= 24 Then
                winner = True
                odds = 2
            ElseIf choice = 5 And ball > 24 And choice <= 36 Then
                winner = True
                odds = 2
            ElseIf choice = 6 And ball = number Then
                winner = True
                odds = 35
            End If

            '4. Output of choice and roll

            Console.WriteLine(vbTab & "The number rolled was: " & ball & " " & color)
            If winner Then
                wager = bet * odds
                Console.WriteLine(vbTab & "You won " & wager.ToString("C"))
                cash = cash + wager
            Else
                Console.WriteLine(vbTab & "You lost " & bet.ToString("C"))
                cash = cash - bet
            End If

            Console.WriteLine(vbTab & "Press any key to continue...")
            Console.ReadKey(True)

            Console.Clear()

            If cash > 0 Then

                Console.WriteLine(vbTab & "Current Cash is: " & cash)
                Console.WriteLine()
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(vbTab & "Press 1 to play Red (1:1)")
                Console.ForegroundColor = ConsoleColor.White
                Console.WriteLine(vbTab & "Press 2 to play Black (1:1)")
                Console.ForegroundColor = ConsoleColor.Cyan
                Console.WriteLine(vbTab & "Press 3 to play the First 12 (2:1)")
                Console.ForegroundColor = ConsoleColor.Magenta
                Console.WriteLine(vbTab & "Press 4 to play the Middle 12(2:1)")
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.WriteLine(vbTab & "Press 5 to play the Last 12(2:1)")
                Console.ForegroundColor = ConsoleColor.DarkCyan
                Console.WriteLine(vbTab & "Press 6 to play any number (35:1)")
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine(vbTab & "Press 7 to cash out and recieve your order")
                Console.Write(vbTab & "Enter gameplay choice: ")
                choice = getInteger()
                Console.WriteLine()

            End If


            While choice < 0 Or choice > 7
                Console.WriteLine(vbTab & "Someday you're going to learn you can't make a joke about everything.")
                Console.Write(vbTab & "Enter gameplay choice: ")
                choice = getInteger()
                Console.WriteLine()
            End While

        End While

        Console.Clear()

        Console.WriteLine(vbTab & "You have " & cash.ToString("C") & ".  Please enjoy your meal at Last Chance Diner.")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine(vbTab & vbTab & vbTab & "        __       __ ")
        Console.WriteLine(vbTab & vbTab & vbTab & "      .'  `'._.'`  '. ")
        Console.WriteLine(vbTab & vbTab & vbTab & "     |  .--;   ;--.  | ")
        Console.WriteLine(vbTab & vbTab & vbTab & "     |  (  /   \  )  | ")
        Console.WriteLine(vbTab & vbTab & vbTab & "      \  ;` /^\ `;  / ")
        Console.WriteLine(vbTab & vbTab & vbTab & "       :` .'._.'. `; ")
        Console.WriteLine(vbTab & vbTab & vbTab & "       '-`'.___.'`-'")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.ReadKey(True)

    End Sub

    Function getInteger() As Integer

        Dim strInput As String
        Dim intInput As Integer

        'read input as string
        strInput = Console.ReadLine()

        'check if it's an integer
        While Decimal.TryParse(strInput, intInput) = False

            Console.WriteLine(vbTab & "I have better things to do than crash")
            Console.Write(vbTab & "Enter a number: ")
            strInput = Console.ReadLine()

        End While

        Return intInput

    End Function

End Module
