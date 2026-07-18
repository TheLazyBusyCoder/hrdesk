I'd recommend building **one project only**:

# Employee Leave & Attendance Management System

This is realistic, common in companies, and teaches almost every important ASP.NET Core MVC concept without becoming overwhelming.

### Features (build in this order)

#### Phase 1 - Foundation

* Login/Logout
* Role-based authentication (Admin, Employee)
* Dashboard
* Profile page

**You'll learn**

* ASP.NET Core Identity
* Authentication
* Authorization
* Layouts
* Dependency Injection

---

#### Phase 2 - Employee Management

* Add employee
* Edit employee
* Delete employee
* Search employees
* Pagination

**You'll learn**

* CRUD
* Entity Framework Core
* LINQ
* Validation
* ViewModels

---

#### Phase 3 - Leave Management

Employees can:

* Apply for leave
* View leave history

Admin can:

* Approve
* Reject
* View pending requests

**You'll learn**

* Relationships (Employee → Leave Requests)
* Enums
* Business logic
* Status handling

---

#### Phase 4 - Attendance

* Mark attendance
* View monthly attendance
* Admin dashboard

**You'll learn**

* DateTime handling
* Aggregation
* Filtering

---

#### Phase 5 - Polish

* Upload profile picture
* Toast notifications
* Logging
* Error pages
* Responsive Bootstrap UI

---

## Database Tables

* Users
* Employees
* Departments
* LeaveRequests
* Attendance
* Roles

Simple but realistic.

---

## Technologies

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* ASP.NET Core Identity
* Bootstrap
* LINQ
* Repository Pattern *(optional but recommended)*
* Dependency Injection

---

## GitHub Activity

Instead of one giant commit:

```
Initial project setup
Add Identity authentication
Implement Employee CRUD
Add pagination
Implement Leave Requests
Admin approval workflow
Attendance module
Profile picture upload
Improve UI
Bug fixes
```

This looks like real development.

---

## Resume

It would read something like:

> **Employee Leave & Attendance Management System**
>
> * Built using ASP.NET Core MVC, Entity Framework Core, SQL Server, and ASP.NET Core Identity.
> * Implemented role-based authentication and authorization (Admin/Employee).
> * Developed employee management, leave approval workflow, attendance tracking, search, pagination, and validation.
> * Applied dependency injection, LINQ, and clean project organization.
> * Version-controlled with Git and hosted on GitHub.
