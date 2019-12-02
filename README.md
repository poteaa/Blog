# Blog

The backend was created using visual studio framework 4.7.
It has 1 solution and 4 projects:
	- BlogData: data access project. 
		- Uses EF code first to create the database.
		- Implements the unit of work pattern to access to the repository from other layers.
	- BlogModel: has the model for the domain of the application
	- BlogAPI: api to expose the endpoints
		- Uses Autofac to inject the dependencies.
	- BlogHelper: has helper classes
		- MapperConfig class
			- Maps from entities to DTO classes.
			- Genrice wrapper for Automapper (pending the implementation of facade pattern or other that can act as a wrapper)
	- BlogTest: unit test proyect
		- Uses NSubstitute to create the mocks
		- Uses NUnit to create unit tests
		- Uses FluetAssertions
	
	
