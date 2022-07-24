# CarReviewApp

PackageManagerConsole -> Add-Migration InitialCreate -> Update-Database
(Migrasi dari code ke Database SQL Server)

Terminal -> dir -> cd CarReviewApp -> dir -> dotnet run seeddata

Structure API:
1. Category
EndPoint: [URL]/api/Category

A.GET
Parameter:
categoryId -> Get Category by categoryId

B.POST / Create
	RequestBody:
{
    	"name": "string"
}

C.PUT / Update
	Parameter: categoryId
	RequestBody:
	{
  		"id": 0,
 		 "name": "string"
}

D.DELETE
	Parameter: categoryId


2. Country
EndPoint: [URL]/api/Country

A.GET
Parameter:
countryId -> Get Country by countryId 

B.POST / Create
	RequestBody:
{
    	"name": "string"
}

C.PUT / Update
	Parameter: countryId
	RequestBody:
	{
  		"id": 0,
 		 "name": "string"
}

D.DELETE
	Parameter: countryId


3. Owner
EndPoint: [URL]/api/Owner

A.GET
Parameter:
ownerId -> Get Owner by ownerId

B.POST / Create
	Parameter: countryId
	RequestBody:
{
 		 "name": "string",
 		 "profession": "string"
}

C.PUT / Update
	Parameter: ownerId
	RequestBody:
	{
		"id": 0,
  		"name": "string",
 		 "profession": "string"
}

D.DELETE
	Parameter: ownerId


4. Reviewer
EndPoint: [URL]/api/Reviewer

A.GET
Parameter:
reviewerId -> Get Reviewer by reviewerId 

B.POST / Create
	RequestBody:
{
 		 "name": "string"
}

C.PUT / Update
	Parameter: reviewerId 
	RequestBody:
	{	
		"id": 0,
  		"name": "string",
}

D.DELETE
	Parameter: reviewerId 


5. Car
EndPoint: [URL]/api/Car

a. GET
Parameter:
carId -> Get Car by CarId

b. POST / Create
Parameter: ownerId, categoryId
Requestbody:
{
  		"name": "string",
  		"manufactureDate": "2022-07-24T10:48:09.597Z"
}

c. PUT / Update
Parameter: carId, ownerId, categoryId
RequestBody:
{
 		"id": 0,
  		"name": "string",
  		"manufactureDate": "2022-07-24T10:50:57.524Z"
}

d. DELETE
Parameter: carId

6. Review
EndPoint: [URL]/api/Review

a. GET
Parameter:
carId -> Get Car by reviewId

b. POST / Create
Parameter: reviewId, carId
Requestbody:
{
  		"title": "string",
 		"text": "string",
  		"rating": 0
}

c. PUT / Update
Parameter: reviewId
RequestBody:
{
 		"id": 0,
  		"title": "string",
 		"text": "string",
  		"rating": 0
}

d. DELETE
Parameter: reviewId

