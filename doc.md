# Documentation

## launching

1. Go to [CarManagement.API](CarManagement.API) directory.
2. Open command line
3. Enter `dotnet run`

## The first Steps

StartPath: `https://localhost:7008/api`

#### 1. Create account(user):

If you prefer Swagger => `https://localhost:7008/swagger/index.html`,
if you prefer Postman =>
Method: `POST`
url: `$"{StartPath}/user"`
Body:
`{
  "username": "string",
  "password": "string",
  "confirmPassword": "string",
  "email": "string",
  "firstName": "string",
  "lastName": "string"
}`

#### 2. Get Token

Method: `POST`
url:`$"{StartPath}/token"`
Body: `{  
  "username": "string",
  "password": "string"}`

## docs

StartPath: `https://localhost:7008/api`

#### 1. Get tokens

Method: `POST`
url:`$"{StartPath}/token"`
Body:
`{ "username": "string",
  "password": "string"}`

#### 2. Refresh tokens

Method: `POST`
url:`$"{StartPath}/token/refresh-token"`
Body:
`{ "accessToken": "string",
  "refreshToken": "string"}`
Headers:
`{ "Name": "username"}`

#### 3. Create user

Method: `POST`
url:`$"{StartPath}/user"`
Body:
`{
  "username": "string",
  "password": "string",
  "confirmPassword": "string",
  "email": "string",
  "firstName": "string",
  "lastName": "string"
}`

#### 4. Update user

Method: `UPDATE`
url:`$"{StartPath}/user/{id}"`
Body:
`{
  "username": "string",
  "password": "string",
  "confirmPassword": "string",
  "email": "string",
  "firstName": "string",
  "lastName": "string"
}`

#### 5. Delete user

Method: `DELETE`
url:`$"{StartPath}/user/{id}"`

#### 6. Create car

Method: `POST`
url:`$"{StartPath}/car"`
Body:
`{ "make": "string",
  "model": "string",
  "year": "int32",
  "price": "int32"}`

#### 7. Get cars

Method: `GET`
url:`$"{StartPath}/car"`

#### 8. Get car by Id

Method: `GET`
url:`$"{StartPath}/car/{id}"`

#### 9. Get car by parameters

Method: `GET`
url:`$"{StartPath}/car/parameters?selectionEdge1={int32}&selectionEdge2={int32}"`

#### 10. Update car

Method: `UPDATE`
url:`$"{StartPath}/user/{id}"`
Body:
`{ "make": "string",
  "model": "string",
  "year": "int32",
  "price": "int32"}`

#### 11. Delete car

Method: `DELETE`
url:`$"{StartPath}/car/{id}"`
