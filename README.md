This application exercise does not only involve the algorithm implementation of the poker hand sorter.
It also demonstrates how to apply clean architecture as an example to an application.
In the application engineering process, domain-driven design, test-driven design and SOLID principles have been used as guidelines.
The Chain of Responsibility Design Pattern is dedicated to archive the separation of concern principle for the rank comparison implementation. 

Assumptions:
1.	A card value must be represented in one of the following characters for test. 
    '2','3','4','5','6','7','8','9','T','J','K','Q','A'
2.	A card suit must be represented in one of the following characters for test.
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
