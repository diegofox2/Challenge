# Challenge
This is a technical challenge required for a technical position as .Net Developer
## Installation instructions

You only have to download the repository, and open it in Visual Studio. It will use the LocalDB server as part of the development process. Therefore to test it locally it is not required to change de connection strings

Before running for first time, run the migrations in order to create the database and the store procedure

`Update-Database`

Once you have run the migration, you can start debugging locally

## Design desitions

The project is following the patterns *Repository* and *Unit of Work*. Also, it is following the recommendations of Domain Driven Design, separating the business logic in Services y Domain entities, avoiding having anemic entities, and using the ubiquitous language

## Testing

The solution have Unit Testing for Domain Classes and Services, and also have Integration Test to validate multiple layers (including the DB) starting from the Services


