This application exercise is not just about the algorithm implementation of the poker hand sorter. It has also demonstrated how a clean architecture can be applied to the application as a sample.
The Domain-Driven Design, Test-Driven Design and SOLID Principles had been used as guideline during the application engineering process. The Chain of Responsibility Design Pattern is selected for the Poker Hand Ranking Evaluator and Rule classes to dedicate the separation of concerns. 

Assumption:
1.	A card value must be represented in one of the following character for test. 
    '2','3','4','5','6','7','8','9','T','J','K','Q','A'
2.	A card suit must be represented in one of the following character for test.
    'D','H','S','C' 
3.	Any exception will terminate the program without further execution.
4.	The application only accepts the input from a text file as poker-hands.txt format that has been provided. 
5.	No validation for the card value or text file format.
6.	The application has only been tested on Windows, not Mac or Linux.
7.	The execution environment has .NET Core 3.1 and .NET Standard 2.1 installed and ready to use.


Folder Structure:

-	Poker.Application
-	Poker.Domain
-	Poker.UnitTests
-	Poker.Data
-	PokerHandSorter (Console Application)


How to execute:

A.	Visual Studio 2019
1. Open PokerHandSorter.sln file from the main folder
2. Select the PokerHandSorter console application project
3. Right click on the project then select Debug Run

B.	Command Prompt
1. Go to PokerHandSorter subfolder from the main folder
2. Type "dotnet run poker-hands.txt" in the PokerHandSorter subfolder
