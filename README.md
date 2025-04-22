# Blogging Platform Microservices

A simple microservices-based blogging platform built with .NET and Docker.

## Overview

This project demonstrates a basic microservices architecture with two services:

1. **PostService** - Manages blog posts
2. **CommentService** - Manages comments on blog posts

Both services are containerized with Docker and can be run together using Docker Compose.

## Architecture

- Each service is built with .NET Web API
- Services communicate via HTTP
- Shared DTOs are defined in a common class library
- In-memory data storage
- Docker containerization

## Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Docker](https://www.docker.com/products/docker-desktop)

## Project Structure

```
BloggingPlatform/
├── Common/                   # Shared models/DTOs
├── PostService/              # Blog post microservice
│   ├── Controllers/
│   ├── Repositories/
│   └── Dockerfile
├── CommentService/           # Comments microservice
│   ├── Controllers/
│   ├── Repositories/
│   ├── Services/             # Contains PostService client
│   └── Dockerfile
└── docker-compose.yml        # Docker Compose configuration
```

## Building and Running

### Using Docker Compose

```bash
# Build and start the services
docker-compose build
docker-compose up

# Stop the services when done
docker-compose down
```

### Manual Development Setup

```bash
# Run PostService
cd PostService
dotnet run

# Run CommentService (in a separate terminal)
cd CommentService
dotnet run
```

## API Endpoints

### PostService (http://localhost:6001)

- `POST /posts` - Create a new blog post
- `GET /posts` - Get all blog posts
- `GET /posts/{id}` - Get a specific blog post by ID

### CommentService (http://localhost:6002)

- `POST /comments` - Add a comment to a post
- `GET /comments/{postId}` - Get all comments for a specific post

## Example Usage

### 1. Create a New Post

```bash
curl -X POST http://localhost:6001/posts \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Getting Started with .NET",
    "content": "This is a sample blog post."
  }'
```

Response:
```json
{
  "id": "GUID_HERE",
  "title": "Getting Started with .NET",
  "content": "This is a sample blog post."
}
```

### 2. Add a Comment to the Post

```bash
curl -X POST http://localhost:6002/comments \
  -H "Content-Type: application/json" \
  -d '{
    "postId": "GUID_HERE",
    "author": "Jane Doe",
    "text": "Great article!"
  }'
```

### 3. Get Comments for a Post

```bash
curl -X GET http://localhost:6002/comments/GUID_HERE
```

Response:
```json
[
  {
    "author": "Jane Doe",
    "text": "Great article!"
  }
]
```

## Troubleshooting

- **Service Connection Issues**: If the CommentService cannot connect to the PostService, make sure both containers are running and check that the service names in the docker-compose.yml file match the URL being used.

- **Docker Network Issues**: If you encounter network-related errors, try restarting Docker and running `docker-compose down --remove-orphans` before starting the services again.

## Future Improvements

- Add persistent database storage
- Implement authentication and authorization
- Add unit and integration tests
- Implement API gateways
- Add monitoring and logging infrastructure
