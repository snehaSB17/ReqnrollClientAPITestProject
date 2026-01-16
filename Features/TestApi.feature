Feature: TestApi

Background: Create new object
	Given I constructs "POST" for "objects"
	When I pass the request body
	And I submit the request 
	Then I expect Statuscode to be "200"

@tag1
Scenario: Get all objects
	Given I constructs "GET" for "objects"
	When I submit the request 
	Then I expect Statuscode to be "200"

Scenario: Get Request for single object
	Given I constructs "GET" for "objects/{id}"
	When I submit the request 
	Then I expect Statuscode to be "200"

Scenario: Post Request for single object
	Given I constructs "POST" for "objects"
	When I pass the request body
	And I submit the request 
	Then I expect Statuscode to be "200"

Scenario: Update Object
	Given I constructs "PUT" for "objects/{id}"
	When I update the request body
	And I submit the request 
	Then I expect Statuscode to be "200"

Scenario: Partially update Object
	Given I constructs "PATCH" for "objects/{id}"
	When I update partially the request body
	And I submit the request 
	Then I expect Statuscode to be "200"

Scenario: Delete Request
	Given I constructs "DELETE" for "objects/{id}"
	When I submit the request 
	Then I expect Statuscode to be "200"
	And I expect responce message 
	  """  
      {"message":"Object with id = {id} has been deleted."}
      """

Scenario: Get multiple objects by IDs 
	Given I constructs "GET" for "objects?id=1&id=2&id=7"
	When I submit the request 
	Then I expect Statuscode to be "200" 
	And the response should contain objects with ids "1", "2", and "7"
