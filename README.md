# DesignCrowdTechnicalChallenge
This project was completed as part of a coding challenge for a job application with DesignCrowd. I was tasked with creating two methods and a set of rules, the methods would parse two dates (or two dates and a collection of public holidays) and determine how many business days/weekdays occurred between those two dates.
## Task 1
To achieve task one, I implemented a method that would accept two dates and be able to give the number of weekdays between them, excluding the given start and end date and would return 0 if the end date was smaller than the start date.

I created a series of unit tests to prove the correctness of my implementation, factoring in edge cases such as leap years, if the two dates are sequential and covering dates that span across multiple years.

## Task 2
To achieve task two, I implemented a similar method that expanded upon task one. This method would be able to handle a list of public holidays and exclude those from the number of business dates between the given dates. 

To achieve this, I used the implementation of task one to determine how many business days were between the two dates. The method looped through the provided dates and checked to see if they fell on a public holiday - if they did, I would increment a counter that would store the number of public holidays. To get the final value, I took the number of business days and subtracted the number of public holidays.

## Task 3
To achieve task three, I implemented the rules engine design pattern. This allowed me to create a series of independent rules that the date could be tested against, allowing us to check if the date is observed on a Monday or to work out the date of a holiday that doesn't have a fixed date (i.e. Queen’s Birthday). 

With this setup, I can easily write new rules or remove rules if needed. These rules can be expanded upon without the need to interfere with the code or any other rules. The rules engine pattern would easily allow us to set up different rules depending on the location of the user, making this small program quite expandable without needing to refactor the existing rules or implementation of the business day count method.

In the event I was to expand on this project, I would be looking into storing data that is parsed to the rules in either a database or a JSON file that could be parsed, as this would cut down on the number of rules it loops through. I would also make the public holidays more data driven and easier to keep up to date in the future. Integrating with an API that retrieves the public holiday dates for a country/region would also be another possible direction to take when expanding on this project. 

I also noticed a rare edge case that would not be caught by the current implementation, the case in point being Christmas and Boxing Day falling on the weekend (as in the case of 2021). In that instance, the public holidays are to be observed on both Monday and Tuesday.
