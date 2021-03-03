# Centrica Interview #2 Assignment
## Web API + Data Access Layer Repository
## Database SQL queries and stores procedures also included

### SalesPerson Actions:
* Create
Pass a json object containing Name and/or Surname in the body and:
``` POST https://localhost:44325/api/SalesPerson/```
* Read
  *To get one, pass an ID:
  ``` GET https://localhost:44325/api/SalesPerson/{ID}```
  *To get all, use:
  ``` GET https://localhost:44325/api/SalesPerson/```
* Update
Pass a json object containing ID, Name and/or Surname in the body and:
``` PUT https://localhost:44325/api/SalesPerson/{ID}```
* Delete
To get one, pass an ID:
``` DELETE https://localhost:44325/api/SalesPerson/{ID}```

### Store Actions:
* Create
Pass a json object containing Name and/or Info and/or District ID in the body and:
``` POST https://localhost:44325/api/Store/```
* Read
  *To get one, pass an ID:
  ``` GET https://localhost:44325/api/Store/{ID}```
  *To get all, use:
  ``` GET https://localhost:44325/api/Store/```
* Update
Pass a json object containing ID, Name and/or Surname in the body and:
``` PUT https://localhost:44325/api/Store/{ID}```
* Delete
To get one, pass an ID:
``` DELETE https://localhost:44325/api/Store/{ID}```


### District Actions:
* Create
Pass a json object containing Name and Primary Sales Person ID in the body and:
``` POST https://localhost:44325/api/District/```
* Read
  *To get one, pass an ID:
  ``` GET https://localhost:44325/api/District/{ID}```
  *To get all, use:
  ``` GET https://localhost:44325/api/District/```
* Update
Pass a json object containing ID, Name and Primary SalesPerson in the body and:
``` PUT https://localhost:44325/api/District/{ID}```
* Delete
To get one, pass an ID:
``` DELETE https://localhost:44325/api/District/{ID}```

* Append Secondary
Appends a Secondary Sales Person to a District
```POST https://localhost:44325/api/District/appendSecondary/{District_ID}/{SalesPersonID}```
* Remove Secondary
Removes a Secondary Sales Person from a District
```DELETE https://localhost:44325/api/District/removeSecondary/{District_ID}/{SalesPersonID}```
 
* Get List of already Assigned Secondary Salespersons to a District
```GET https://localhost:44325/api/District/getASSP/{District_ID}```
* Get List Salespersons that can be assigned to a District
```GET https://localhost:44325/api/District/getPSSP/{District_ID}```
