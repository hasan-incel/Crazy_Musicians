# Crazy Musicians! API

Welcome to the Crazy Musicians! API, a simple ASP.NET Core Web API that allows you to manage a list of amusing musicians. This project demonstrates CRUD operations with an in-memory database.

## Features

- **Create**: Add new musicians to the list.
- **Read**: Retrieve all musicians or search for a specific musician by name.
- **Update**: Fully update or partially update a musician's details.
- **Delete**: Remove a musician from the list.

## API Endpoints

### Get All Musicians
- **Endpoint**: `GET /api/musicians`
- **Description**: Retrieves a list of all musicians.

### Get Musician by ID
- **Endpoint**: `GET /api/musicians/{id}`
- **Description**: Retrieves a musician by their ID.

### Search Musicians
- **Endpoint**: `GET /api/musicians/search`
- **Query Parameter**: `name` (string)
- **Description**: Searches for musicians by name.

### Create a New Musician
- **Endpoint**: `POST /api/musicians`
- **Request Body**: 
    ```json
    {
        "Name": "Musician Name",
        "Profession": "Musician Profession",
        "FunFeature": "Fun Feature Description"
    }
    ```
- **Description**: Adds a new musician to the list.

### Update a Musician
- **Endpoint**: `PUT /api/musicians/{id}`
- **Request Body**: 
    ```json
    {
        "Name": "Updated Name",
        "Profession": "Updated Profession",
        "FunFeature": "Updated Fun Feature"
    }
    ```
- **Description**: Updates the musician's details.

### Partially Update a Musician
- **Endpoint**: `PATCH /api/musicians/{id}`
- **Request Body**: 
    ```json
    {
        "Name": "New Name" // Only include properties you want to update
    }
    ```
- **Description**: Updates specific properties of a musician.

### Delete a Musician
- **Endpoint**: `DELETE /api/musicians/{id}`
- **Description**: Removes a musician from the list.

## Getting Started

### Prerequisites
- .NET SDK (version 6.0 or later)
- A code editor (e.g., Visual Studio, VS Code)

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/Crazy_Musicians.git
    cd Crazy_Musicians
    ```
2. Restore dependencies:
    ```bash
    dotnet restore
    ```

3. Run the application:
    ```bash
    dotnet run
    ```

### Testing the API
You can test the API using tools like [Postman](https://www.postman.com/) or Swagger.

## Contributing
Contributions are welcome! Feel free to submit a pull request.

## License
This project is licensed under the MIT License.
