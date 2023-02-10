# BettingAPI
Requirements
	.NET Core 3.1 or later

Dependencies
	The application uses the following dependencies:
		Microsoft.AspNetCore.Mvc.Core
		Microsoft.EntityFrameworkCore

Steps to run the application
	Clone the repository.
	Open the project in Visual Studio.
	Build the solution.
	Run the application.
	Open Postman and make the desired API calls using the examples provided above.

	#FixtureService
		1.To create a new fixture:
			Method: POST
			URL: /FixtureService/AddFixture
			Body:
			{
			"Sport": "Soccer",
			"Name": "Real Madrid vs Barcelona"
			}

		2.To retrieve a single fixture:
			Method: GET
			URL: /FixtureService/GetFixture/1
		
		3.To retrieve all fixtures:
			Method: GET
			URL: FixtureService/GetFixtures

	#BettingService
		1.To place a bet on a fixture:
			Method: POST
			URL: /BettingService/bets
			Body:
			{
			 "FixtureId": 1,
			 "MatchWinner": "Barcelona"
			}
		2.To retrieve a bet:
			Method: GET
			URL: /BettingService/GetBet/1
		3.To retrieve the result of a bet:
			Method: GET
			URL: /BettingService/GetBetResult/1

Steps to run the application in Docker
	Clone the repository.
	Open a terminal or command prompt in the root folder of the repository.
	Build the Docker image using the following command
		docker build -t SportingGroupAPI .
	Run a Docker container from the image using the following command
		docker run -d -p 8080:80 SportingGroupAPI
	The API will be running at http://localhost:8080

Note
	In the command docker run -d -p 8080:80 SportingGroupAPI, the option -p 8080:80 maps 
	the host's port 8080 to the container's port 80, which is the port exposed by the API. 
	If you wish to use a different host port, you can change 8080 to any available port on 
	your machine.
