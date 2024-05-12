# Employee API
```html
@host = http://localhost:8181


GET http://dummy.restapiexample.com/api/v1/employees
###


GET {{host}}/employees/list
###
Content-Type: application/json
###

//Filter By Age
GET {{host}}/employees/filter?Sort=Age
###
Content-Type: application/json
###

//Filter By Salary
GET {{host}}/employees/filter?Sort=Salary
###
Content-Type: application/json
###

//Filter By Name
GET {{host}}/employees/filter?Sort=Name
###
Content-Type: application/json
###

// Validation of request model.
GET {{host}}/employees/filter
###
Content-Type: application/json
###
```
Code coverage: https://github.com/FortuneN/FineCodeCoverage/releases

![Coverage](https://github.com/abaksheiev/employees-test/blob/master/Content/imgs/testCoverage.png)

![Summary](https://github.com/abaksheiev/employees-test/blob/master/Content/imgs/Summary.png)

