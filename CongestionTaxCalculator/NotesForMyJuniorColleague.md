# hello friend

0. this is the most important=> there is not any "var" in the Programm, you can see all things Type,
===>>> I called this "transparency" | to get a deep understanding please start with "Program.cs" :)

 
1. I Wrote some tips and comments for you in "DynamicCongestionTaxCalculatorController.cs"
2. now here time is 5:40 AM And Im Working 
3. as you can see I changed whole project, but your codes and notes helped me
4. I refactore your code one time, then I refactore my own code more than 30 time. I dont know why this project is so interesting for me
5. I might fail the test because of a cold. And also maybe because I am ambitious and want to improve my work frequently. Right now, I'm thinking about refactoring a few more parts. And all this took me a lot of time and I made a big thing out of a short test. Last night I was researching and studying for this exam until 7 am. I always took the writing unit test very superficially and usually did not do it. But now I have a contract with him for this project. Now it is the project itself that is important to me and not the test. Meanwhile, I jokingly call you Junior. In general, the concepts of junior and senior are strange to me. In my opinion, in programming, someone who practices and studies with love every day is a senior. How much did I talk, I must do a short refactor due to the pressure of my work, and then I will go to the last giant, which is the bonus scenario.
6. Ok, after 2 days of coding that I spend 60% of it to think and find the best way to implement "Bonus Scenario"
   I just look at the name of program, "CongestionTaxCalculator", and I asked mySelf:
				""""  were am I saving the Calculated Tax :) ?  """"

7. so now I add Base Rule. Admin, Operator or whatever they say, can add baseRules For any country and town for any vehicle type and any spesific date and
 more like that, then I add "DynamicCongestionTaxCalculatorController" two first method will calculate By Date or DATE_RANGE,
 and other methods are documented.

8. still we are limited in paarameters , I can build an Formula builder. I done this three time in three different projct with three different scenario.
 actually in this project is so easy to do something like that, but the bonus scenario is not clear for me, why external data source?
 i researched about API's that give this ability they all are premium and they all are confusing and non of them. even a single one of them have not a good
 or at least readable documentation and this is so much boring. in another way just look at the scenario:
 "## Bonus Scenario

Just as you finished coding, your manager shows up and tells you that 
	{{{the same application should be used in other cities with different tax rules. (me: ok sir thats so easy)
	These tax rules need to be handled as content outside the application. (me: umm, sorry but what do you mean from "content outside the application"?)
	because different content editors for different cities will be in charge of keeping the parameters up to date.
	(me: ok, sorry sir what you mean from different "parameters" and "keeping the parameters up to date"?)
	Move the parameters used by the application to an outside data store of your own choice to be read during runtime by the application.
	(me: sure sir. currently im using MSSQL to save data and Store And Read them During RunTime but sir can you explain more... [in this part he left]) }}}
	
	me[talking to myself]: parameters? content writers? keeping the parameters up to date? outside the app? [here im searching web and ai chats]
	so many different things, [use json ! use api ! traffic api ! geo location ! "sorry your Ip is banned you are from iran, maybe have a bomb :/"
	let me see AI helpers, [the same, same, same. oh cool this ai *****************************************]
	ok, I Can Do That, I Will Do That, Maybe Currently I done it but i dont know! because there was not enough description, also Now , right now,
	i wrote an app with dynamic base rules, user can add and change parameters, user can add baseRule,TaxRule, even can add his calculated data,
	also can add and get calculatex Tax with his parameters, for a day, for a range of day.
	ok. maybe I I I I => "I JUST ADD A FORMUL BUILDER, THEN HE CAN DO ANY THING THAT HE WANT TO DO :)

